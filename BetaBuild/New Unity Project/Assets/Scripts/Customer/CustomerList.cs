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

        customer_go.transform.localPosition = new Vector3(20, -140, 0); //UI4-5
        customer_go.transform.SetSiblingIndex(1);

        //Change the demand, so its based off affinity.. Income already we have kinda?

        if (spawn_customer == 0)
        {
            Customer c = new Customer("Awa", 1, 10000, 200, new Quirk[0], curr_item, customer_go, dialogue_list[1], 1);
            c.name = "Awa";
            return c;
        }
        else if (spawn_customer == 1)
        {
            Customer c = new Customer("Rokhaya", 1, 20000, 100, new Quirk[0], curr_item, customer_go, dialogue_list[2], 2);
            c.name = "Rokhaya";
            return c;
        }
        else if (spawn_customer == 2)
        {
            Customer c = new Customer("Abdou", 1.2f, 30000, 60, new Quirk[0], curr_item, customer_go, dialogue_list[0], 4);
            c.name = "Abdou";
            return c;
        }
        else if (spawn_customer == 3)
        {
            Customer c = new Customer("Mohammed", 0.9f, 100, 150, new Quirk[0], curr_item, customer_go, dialogue_list[3], 0);
            c.name = "Mohammed";
            return c;
        } /*else if (spawn_customer == 4)
        {
            Customer c = new Customer("Musu", 1, 1, 100, new Quirk[0], curr_item, customer_go, dialogue_list[0], 1);
            c.name = "Musu";
            return c;
        }
        else if (spawn_customer == 5)
        {
            Customer c = new Customer("Diouf", 1, 3, 100, new Quirk[0], curr_item, customer_go, dialogue_list[0], 1);
            c.name = "Diouf";
            return c;
        }
        else if (spawn_customer == 6)
        {
            Customer c = new Customer("Amy", 1, 5, 100, new Quirk[0], curr_item, customer_go, dialogue_list[0], 1);
            c.name = "Amy";
            return c;
        }
        else if (spawn_customer == 7)
        {
            Customer c = new Customer("Khadija", 1, 2, 90, new Quirk[0], curr_item, customer_go, dialogue_list[0], 1);
            c.name = "Khadija";
            return c;
        }
        else if (spawn_customer == 8)
        {
            Customer c = new Customer("Fatou", 1, 4, 70, new Quirk[0], curr_item, customer_go, dialogue_list[0], 1);
            c.name = "Fatou";
            return c;
        }
        else if (spawn_customer == 9)
        {
            Customer c = new Customer("Marie", 1, 1, 120, new Quirk[0], curr_item, customer_go, dialogue_list[0], 1);
            c.name = "Marie";
            return c;
        }*/
        else
        {
            Debug.Log(spawn_customer);
            Debug.Log("ERROR: Customer index out of range");
            return null;
        }
    }

    public void DestroyCustomerGO() {
        Destroy(customer_go);
    }
}
