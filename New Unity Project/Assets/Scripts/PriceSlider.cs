using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PriceSlider : MonoBehaviour
{

    public Text priceText;
    private int maxPrice;

    void Start()
    {
        maxPrice = 100;
        priceText = GetComponent<Text>();
    }

    // Update is called once per frame
    public void textUpdate(float value)
    {
      print("hello??" + value.ToString());
      priceText.text =  Mathf.RoundToInt(value * maxPrice).ToString();

    }
}
