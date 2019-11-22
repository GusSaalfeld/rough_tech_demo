using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{

    public List<GameObject> items;
    private GameObject item_go;

    //ENSURE gameobject images match itemID, this is a terrible system on my part fyi but it works so whatever
    public Item ItemCreator() {
        int itemID = Random.Range(0, items.Count);
        item_go = Instantiate(items[itemID]);
        item_go.transform.SetParent(transform.parent.transform);
        item_go.transform.localPosition = new Vector3(280, 51, 0); //use for UI4 & UI5
        //item_go.transform.localPosition = new Vector3(-202, -70, 0); //use for UI 1-3


        if (itemID == 0)
        {
           return new Item("apple", 5.00, 7.50);
        }
        else if (itemID == 1) {
            return new Item("banana", 5.00, 7.50);
        } else
        {
            Debug.Log("ERROR: Item index out of range");
            return null;
        }
    }

    public void DestroyItemGO()
    {
        Destroy(item_go);
    }
}
