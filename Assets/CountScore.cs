using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountScore : MonoBehaviour
{
    public UnityEngine.UI.Text scoreText;
    // Start is called before the first frame update

    private void OnCollisionEnter(Collision collision)
    {
        string scoreT = scoreText.text.ToString();
        int score = int.Parse(scoreT) + 100;
        scoreText.text = score.ToString();
        Destroy(collision.gameObject);
    }
}
