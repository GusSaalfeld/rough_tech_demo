using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
//hosts all info about single dialogue
public class Dialogue
{
    public string name;

    [TextArea(3,10)]
    public string[] lines;

}
