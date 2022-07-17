using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DestroyAim : MonoBehaviour
{
    public UnityEngine.UI.Text scoreText;
    private int score = 100;

    private void OnCollisionEnter(Collision collision)
    {
        string scoreT = scoreText.text.ToString();
        score += int.Parse(scoreT);
        scoreText.text = score.ToString();
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
