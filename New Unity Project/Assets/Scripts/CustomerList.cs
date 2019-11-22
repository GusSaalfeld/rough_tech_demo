using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerList : MonoBehaviour
{
    public List<GameObject> customer_go_list;
    private GameObject customer_go;
    //private Image image;
    public List<Dialogue> dialogue_list;

    public Customer CustomerCreator(Item curr_item)
    {
        int spawn_customer = Random.Range(0, customer_go_list.Count);
        customer_go = Instantiate(customer_go_list[spawn_customer]);

        customer_go.transform.SetParent(transform.parent.transform);
        //customer_go.transform.localPosition = new Vector3(125, -130, 0); //UI1-3 use this position
        customer_go.transform.localPosition = new Vector3(20, -140, 0); //UI4-5
        customer_go.transform.SetSiblingIndex(1);

        if (spawn_customer == 0)
        {
            Customer c = new Customer("Musu", 0.5, 10000, 100, new Quirk[0], curr_item, customer_go, dialogue_list[0]);
            c.dialogue.name = "Musu";
            return c;
        }
        else if (spawn_customer == 1)
        {
            Customer c = new Customer("Diouf", 0.5, 10000, 100, new Quirk[0], curr_item, customer_go, dialogue_list[0]);
            c.dialogue.name = "Diouf";
            return c;
        }
        else
        {
            Debug.Log("ERROR: Customer index out of range");
            return null;
        }
    }

    public void DestroyCustomerGO() {
        Destroy(customer_go);
    }
}
