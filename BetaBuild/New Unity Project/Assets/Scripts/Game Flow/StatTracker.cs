using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StatTracker
{
    private static double score;
    private static string scoreText;

    public static double Score 
    {
        get 
        {
            return score;
        }
        set 
        {
            score = value;
        }
    }

    public static string ScoreText 
    {
        get 
        {
            return scoreText;
        }
        set 
        {
            scoreText = value;
        }
    }
}