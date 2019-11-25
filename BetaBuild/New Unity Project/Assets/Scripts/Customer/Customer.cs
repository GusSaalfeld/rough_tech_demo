using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer
{
      double demand, frustration;
      public float income;
      public int incomeBracket;
      public float[] incomeBracketMultiplier = new float[] {2.5f, 3f, 3.5f, 3.8f, 4f};
      public float[] fustrationRound;
      int frustrationMax, offerNum;
      public Quirk[] quirks;
      public string name;
      public Item item;
      public int[] frustrationTable;
      public GameObject customerGO;
      public Dialogue dialogue;
      public ExpressionChanges expressions;
    public double finalOffer;

    public Customer(string n, double d, int inc, int fm, Quirk[] q, Item it, GameObject cGO, Dialogue dia, int incomeBracket)
    {
        double qd = 0;
        int qi = 0;
        int qf = 0;
        for (int i = 0; i < q.Length; i++)
        {
            qd += q[i].demand;
            qi += q[i].income;
            qf += q[i].frustration;
        }
        name = n;
        //stored as value representing percent of market price they are willing to pay
        demand = d + qd;
        income =  incomeBracketMultiplier[incomeBracket] + qi;
        frustration = 0;
        frustrationMax = (fm + qf);
        quirks = q;
        item = it;
        offerNum = 0;
        //percent above true value: [<10%, 10-20%, 20-30%, 30-40%, 50-60%, 60-70%, 70-80%, 80-90%, >90%]
        frustrationTable = new int[] { 5, 10, 10, 20, 25, 30, 45, 60, 80, 80 };
        fustrationRound = new float[] {1, 0.5f, 1f, 1.5f, 2f, 2.5f, 3f, 5f, 5f, 5f, 10f, 20f, 50f, 1000000f};
        customerGO = cGO;
        dialogue = dia;
        
        expressions = cGO.GetComponent<ExpressionChanges>();
    }

    //note that offerNum and frustration are only incremented in this method (not in counterOffer)
    //No deal == 0
    // Deal == 1
    //Walk away == 2
    
    double happyPrice = 0;
    double maxPrice = 0;
    public bool firstRound = true;
    public int offerAccepted(double offer)
    {

        if(offer <= happyPrice) {
            finalOffer = (float)offer;
            return 1;
        }

        offerNum += 1;

        if(firstRound) {
            maxPrice = demand * item.marketPrice * (income / 3);
            firstRound = false;        
        }

        //Possible feature, if you go under their max price, it readjusts their negotiation.
        /*if(maxPrice > offer) {
            //Debug.Log("Readjusting max price!");
            maxPrice -= 1;
            if(maxPrice < offer + 1) maxPrice = offer + 1;
        }*/

        
        double incValue = 1.3 * Math.Log(offerNum, 11) * (offer - (maxPrice * .75));
        //TODO: consider hyperbolic function?


        //increase frustration by amount proportional to offer
        double percentOver = (offer - maxPrice) / maxPrice;
        //percentOver should be between 0.1 and 1
        if (percentOver < 0.1)
        {
            percentOver = 0.1;
        }
        if (percentOver > 1)
        {
            percentOver = 1;
        }

        double frustrationMult = fustrationRound[offerNum];
        int frustrationVal = (int)(percentOver * 10) - 1;
        bool walkAway = increaseFrustration(frustrationTable[frustrationVal] * frustrationMult);
        if(walkAway == true) return 2;

        //0.75 as placeholder for percentage of maxPrice that happyPrice is initialized to
        happyPrice = maxPrice * 0.70 + incValue;
        double rangeMin = offer - happyPrice;

        Debug.Log("incValue: " + incValue);
        //Debug.Log("happyPrice: " + happyPrice);
        //Debug.Log("rangeMin: " + rangeMin);
        //Debug.Log("maxPrice: " + maxPrice);
        //Debug.Log("offer: " + offer);

        //rangeMin means if within 10 cents just say yes
        if (happyPrice >= offer || rangeMin <= 0.1)
        {
            finalOffer = (float)offer;
            return 1;
        }
        else
        {
            Debug.Log("offer rejected");
            return 0;
        }
    }

    //precondition: offer > happy price
    public double counterOffer(double offer)
    {
        double maxPrice = demand * item.marketPrice * (income / 3);       
        double incValue = 1.3 * Math.Log(offerNum, 11) * (offer - (maxPrice * .75));
        happyPrice = maxPrice * 0.70 + incValue;
        double percent = happyPrice / offer;
        return happyPrice;
        //TODO: make this depend on income somehow... maybe have income levels?
        //TODO: make this depend on number of offers made and offer history
    }

    //increments frustration by input value
    //Implement threaten to walk away by checking to see if meets threat threshold
    //change to int, return 0 if no threat, 1 if threat, 2 if walk away
    public bool increaseFrustration(double f)
      {
            frustration += f;
            expressions.changeExpression(frustration, frustrationMax);

            if (frustration >= frustrationMax) {
                  Debug.Log(name + " has walked away." );
                  return true;
            }
            return false;
      }

      public void decreaseFrustration(int f)
      {
      		if (frustration <= 0)
      		{
      			frustration = 0;
      		} else {
      			frustration = frustration - f;
      		}	
            expressions.changeExpression(frustration, frustrationMax);
      }

      public void increaseDemand(double d)
      {
      		demand += d;
            firstRound = true;
      }
}