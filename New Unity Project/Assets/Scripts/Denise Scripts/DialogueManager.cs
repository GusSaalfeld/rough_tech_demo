using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Text charismaText;
    public Text priceField;
    public Button charismaButton;
    public Image charismaButtonImage;
    public Button frustrationButton;
    public Button demandButton;
    public int playerPrice;

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

            Debug.Log("starting dialogue");
            curr_item = item_list.GetComponent<ItemList>().ItemCreator();  //Make this based on the item list at some point;
            curr_cust = customer_list.GetComponent<CustomerList>().CustomerCreator(curr_item);
           // dialogueText.dialogue = curr_cust.dialogue;
            
            nameText.text = curr_cust.dialogue.name;
            lines = curr_cust.dialogue.lines;
            dialogueText.text = lines[0];
            startedConvo = true;
        }
        if (numCustomers >= maxCustomers) {
            dialogueText.text = "Game over!";
        }
    }

   public void DisplayNext()
   {
        if (startedConvo == true)
        {
            Debug.Log("in dialogue");
            playerPrice = int.Parse(priceField.text); //assume user inputs int
            int outcome = curr_cust.offerAccepted(playerPrice);
            if (outcome == 0) {  //No deal, counteroffer
                double counter = curr_cust.counterOffer(playerPrice);
                dialogueText.text = lines[2] + " " + (int)counter + " instead?";
            } else if (outcome == 1) {   //deal
                Debug.Log("DEAL!");

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
   dialogueText.text = lines[3];
   charisma++;
   charismaButton.interactable = true;
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

    Debug.Log("End");
  }

  public void iDemand(double d)
  {
    curr_cust.increaseDemand(d);
    Debug.Log("Demand increased");
    charisma = 0;
    charismaButton.interactable = false;
    hideCharismaOptions();
  }


    public void decreaseFrustration(int f)
  {
    curr_cust.decreaseFrustration(f);
    Debug.Log("Frustration lowered!");
    charisma = 0;
    charismaButton.interactable = false;
    hideCharismaOptions();
  }

  public void showCharismaOptions()
  {
    frustrationButton.interactable = true;
    demandButton.interactable = true;
  }

  public void hideCharismaOptions()
  {
    frustrationButton.interactable = false;
    demandButton.interactable = false;
  }
}
