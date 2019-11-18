using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quirk : MonoBehaviour
{
      public double demand;
      public int income, frustration;
      public string description;
      
      public Quirk(string s, double d, int i, int f) {      
            description = s;
            demand = d;
            income = i;
            frustration = f;
      }
}
