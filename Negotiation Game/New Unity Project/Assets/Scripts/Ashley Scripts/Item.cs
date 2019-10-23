using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
      public double buyPrice, marketPrice;
      public string name;
      
      public Item(string n, double b, double m) {
      	    name = n;
            buyPrice = b;
            marketPrice = m;
      }
}
