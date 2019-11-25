using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDisplay : MonoBehaviour
{

    private GameObject displayItem;
    private bool displayingItem;

    public void newConvo(GameObject shownObject)
    {
        if (!displayingItem)
        {

            GameObject displayItem = Instantiate(shownObject, new Vector2(0, 0), Quaternion.identity);
            displayItem.transform.SetParent(transform.parent.transform);
            displayingItem = true;
            Debug.Log("instantiated");
        }
    }

    public void destroyDisplayItem() {
        Destroy(displayItem);
        displayingItem = false;
    }
  }
