using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScript : MonoBehaviour
{

    public int charisma; // max charisma
    public int cp;
    public int tic;
    public float xpos;
    public float ypos;
    public FirstScript(int total)
    {
      charisma =  total;
    }

    public void LowerFrus(int cost){
      cp -= cost; //possible to input cost?
      //player.frustration -= 1; // lowers player frustration
    }

    public void restore(){
      cp = charisma;
    }
    // Start is called before the first frame update
    void Start()
    {
      cp = charisma;
      tic = 0;
      var charBar = transform.position;
      xpos = charBar.x + Screen.width/2;
      ypos = charBar.y + Screen.height/2;
    }

    // Update is called once per frame
    void Update()
    {
      tic++;
      if (Input.GetButtonDown("Fire1")){
        Vector3 coord = Input.mousePosition;

        if (coord.x >= xpos - 100 && coord.x <= xpos + 100 && coord.y >= ypos - 100 && coord.y <= ypos + 100){
          LowerFrus(10);
        }
      }
      if (tic%300 == 0){
        restore();
      }
    }
  }
