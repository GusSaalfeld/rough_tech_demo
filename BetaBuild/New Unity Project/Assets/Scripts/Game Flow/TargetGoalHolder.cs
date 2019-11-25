using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetGoalHolder : MonoBehaviour
{
    public Text field;

    public int targetGoal = 50;

    public void setTargetInt() {
        targetGoal = int.Parse(field.text);
    }
}
