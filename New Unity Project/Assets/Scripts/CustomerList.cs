using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerList : MonoBehaviour
{
    public List<GameObject> customer_go_list;
    private GameObject customer_go;
    public List<Dialogue> dialogue_list;

    public Customer CustomerCreator(Item curr_item)
    {
        int spawn_customer = Random.Range(0, customer_go_list.Count);
        customer_go = Instantiate(customer_go_list[spawn_customer]);
        customer_go.transform.SetParent(transform.parent.transform);
        customer_go.transform.localPosition = new Vector3(0, -130, 0);
        customer_go.transform.SetSiblingIndex(1);

        if (spawn_customer == 0)
        {
            Customer c = new Customer("Awa", 0.5, 10000, 100, new Quirk[0], curr_item, customer_go, dialogue_list[0]);
            c.dialogue.name = "Awa";
            return c;
        }
        else if (spawn_customer == 1)
        {
            Customer c = new Customer("Rokhaya", 0.5, 10000, 100, new Quirk[0], curr_item, customer_go, dialogue_list[1]);
            c.dialogue.name = "Rokhaya";
            return c;
        }
        else if (spawn_customer == 2)
        {
            Customer c = new Customer("Abdou", 0.5, 10000, 100, new Quirk[0], curr_item, customer_go, dialogue_list[2]);
            c.dialogue.name = "Abdou";
            return c;
        }
        else if (spawn_customer == 3)
        {
            Customer c = new Customer("Mohammed", 0.5, 10000, 100, new Quirk[0], curr_item, customer_go, dialogue_list[3]);
            c.dialogue.name = "Mohammed";
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
