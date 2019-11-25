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
           return new Item("apple", 5.00);
        }
        else if (itemID == 1) {
            return new Item("banana", 6.00);
        } 
        else if (itemID == 2) {
            return new Item("basket", 10);
        } 
        else if (itemID == 3) {
            return new Item("bracelet", 11);
        } 
        else if (itemID == 4) {
            return new Item("candy bar", 7);
        } 
        else if (itemID == 5) {
            return new Item("madd", 4);
        } 
        else if (itemID == 6) {
            return new Item("notebook", 5.50);
        } else if (itemID == 7) {
            return new Item("pen", 4.5);
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
