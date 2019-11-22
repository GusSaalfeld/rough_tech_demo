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
            Customer c = new Customer("Musu", 0.5, 1, 100, new Quirk[0], curr_item, customer_go, dialogue_list[0]);
            c.dialogue.name = "Musu";
            return c;
        }
        else if (spawn_customer == 1)
        {
            Customer c = new Customer("Diouf", 0.5, 3, 100, new Quirk[0], curr_item, customer_go, dialogue_list[0]);
            c.dialogue.name = "Diouf";
            return c;
        }
        else if (spawn_customer == 2)
        {
            Customer c = new Customer("Amy", 0.75, 5, 50, new Quirk[0], curr_item, customer_go, dialogue_list[0]);
            c.dialogue.name = "Amy";
            return c;
        }
        else if (spawn_customer == 3)
        {
            Customer c = new Customer("Khadija", 0.3, 2, 90, new Quirk[0], curr_item, customer_go, dialogue_list[0]);
            c.dialogue.name = "Khadija";
            return c;
        }
        else if (spawn_customer == 4)
        {
            Customer c = new Customer("Fatou", 0.9, 4, 70, new Quirk[0], curr_item, customer_go, dialogue_list[0]);
            c.dialogue.name = "Fatou";
            return c;
        }
        else if (spawn_customer == 5)
        {
            Customer c = new Customer("Marie", 0.5, 1, 120, new Quirk[0], curr_item, customer_go, dialogue_list[0]);
            c.dialogue.name = "Marie";
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
