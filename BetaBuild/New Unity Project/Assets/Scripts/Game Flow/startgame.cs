using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startgame : MonoBehaviour
{
    public GameObject targetGoal;

    public void game_starter() {
        Object.DontDestroyOnLoad(targetGoal);
        SceneManager.LoadScene("UI4");
    }
}
