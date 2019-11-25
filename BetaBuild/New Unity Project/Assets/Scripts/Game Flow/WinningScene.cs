using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinningScene : MonoBehaviour
{
	public Text scoreTextObj;
    // Start is called before the first frame update
    void Start()
    {
        scoreTextObj.text = StatTracker.ScoreText;
    }



    public void exitGame()
    {
        Debug.Log("Loading scene");
    	Application.Quit();
    }

    public void RestartGame()
    {
        Debug.Log("Loading scene");
    	SceneManager.LoadScene("UI4");
    }
}
