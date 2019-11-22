using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ExpressionChanges : MonoBehaviour
{
    public Sprite neutral;
    public Sprite mad;
    public Sprite happy;

    // Update is called once per frame
    public void changeExpression(int frustration, int frustrationMax)
    {
        if (frustration > frustrationMax / 2)
        {
            this.GetComponent<Image>().sprite = mad;
        }
        else if (frustration < frustrationMax / 3)
        {
            this.GetComponent<Image>().sprite = happy;
        }
        else
        {
            this.GetComponent<Image>().sprite = neutral;
        }
    }
}
