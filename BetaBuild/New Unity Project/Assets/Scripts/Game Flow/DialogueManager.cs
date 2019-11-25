using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Text priceField;
    public Text cust_income;
    public Text scoreText;
    //For the buttons.
    public Text frustrationText;
    public Text demandText;
    double scoreNum = 0;
    public Button frustrationButton;
    public Button demandButton;
    public Text item_mP;
    public double playerPrice;

    public ObjectDisplay objDis;

    private string[] lines; // opening lines

    public int customerNum;
    private int pick;

    public GameObject item_list;
    public GameObject customer_list;

    private Item curr_item;
    private Customer curr_cust;

    private bool startedConvo = false;

    //public GameObject pricePoint; // function that gets value of customer price range
    private int upperBound;
    private int desiredPrice;

    public int maxCustomers;
    private int numCustomers;
    //have customer max, check at end.

    //Charisma mechanism
    public int charisma;

    public void StartDialogue()
    {
        if (startedConvo == false && numCustomers < maxCustomers)
        {
            showCharismaOptions();
            Debug.Log("starting dialogue");
            curr_item = item_list.GetComponent<ItemList>().ItemCreator();  //Make this based on the item list at some point;
            curr_cust = customer_list.GetComponent<CustomerList>().CustomerCreator(curr_item);
           // dialogueText.dialogue = curr_cust.dialogue;

            nameText.text = curr_cust.name;
            cust_income.text = "income: $" + curr_cust.income.ToString();

            item_mP.text = "Market Price: $" + curr_item.marketPrice.ToString();

            lines = curr_cust.dialogue.lines;
            dialogueText.text = lines[0] + " " +curr_item.name+"?";
            startedConvo = true;
        }
        if (numCustomers >= maxCustomers) {
            dialogueText.text = "Game over!";
            StatTracker.Score = scoreNum;
            
            if(GameObject.FindWithTag("targetholder").GetComponent<TargetGoalHolder>().targetGoal <= scoreNum) {
                StatTracker.ScoreText = "You won! You made a ₣" + ((float)StatTracker.Score).ToString() + " profit! Can you beat your score next time?";
            } else {
                StatTracker.ScoreText = "You lost! You made a ₣" + ((float)StatTracker.Score).ToString() + " profit! Your goal was ₣" + GameObject.FindWithTag("targetholder").GetComponent<TargetGoalHolder>().targetGoal + ". Can you do better next time?";
            }
            //statTracker.scoreTextObj.text = statTracker.scoreText;
            SceneManager.LoadScene("WinningScene");
        }
    }

   public void DisplayNext()
   {
        if (startedConvo == true)
        {
            //Debug.Log("in dialogue");
            playerPrice = double.Parse(priceField.text); //assume user inputs int
            int outcome = curr_cust.offerAccepted(playerPrice);
            if (outcome == 0) {  //No deal, counteroffer
                double counter = curr_cust.counterOffer(playerPrice);
                dialogueText.text = lines[2] + " " + (float)counter + " instead?"; //Fix up.
            } else if (outcome == 1) {   //deal
                //Debug.Log("DEAL!");
                dialogueText.text = lines[3];

                //Debug.Log("final offer: " + curr_cust.finalOffer);
                scoreNum += (float)curr_cust.finalOffer;
                scoreText.text = "₣" + scoreNum.ToString();

                EndDialogue();
            } else if (outcome == 2) {   // walk away
                Debug.Log("Walk away fustration");
                dialogueText.text = lines[4];
                EndDialogue();
            }
        }
  }

  void EndDialogue()
  {
   charisma++;
   if (charisma == 3) {
       charisma = 0;
   }
    
    numCustomers++;
    item_list.GetComponent<ItemList>().DestroyItemGO();
    customer_list.GetComponent<CustomerList>().DestroyCustomerGO();

    //Supposedly garbage collection will then delete them if nothing is pointing to them
    curr_cust = null;
    curr_item = null;

    startedConvo = false;
  }

 public void increaseDemand(int d)
  {
    curr_cust.increaseDemand(d);
    Debug.Log("Demand increased");
    charisma = 0;
    dialogueText.text = lines[7];
    //charismaButton.interactable = false;
    hideCharismaOptions();
  }


    public void decreaseFrustration(int f)
  {
    curr_cust.decreaseFrustration(f);
    Debug.Log("Frustration lowered!");
    charisma = 0;
    dialogueText.text = lines[8];
    //charismaButton.interactable = false;
    hideCharismaOptions();
  }

  public void showCharismaOptions()
  {
    frustrationButton.interactable = true;
    frustrationText.color = Color.black;

    demandButton.interactable = true;
    demandText.color = Color.black;
  }

  public void hideCharismaOptions()
  {
    frustrationButton.interactable = false;
    frustrationText.color = new Color(0, 0, 0, 0);

    demandButton.interactable = false;
    demandText.color = new Color(0, 0, 0, 0);
  }
}
