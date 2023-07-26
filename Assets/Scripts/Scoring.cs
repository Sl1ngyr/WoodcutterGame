using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Scoring : MonoBehaviour
{
    public Text scoreText;
    
    private int _scoreBranch = 0;
    // Start is called before the first frame update
    void Start()
    {
        _scoreBranch = 0;
    }

    public void AddScore(int newScore)
    {
        _scoreBranch += newScore;
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + _scoreBranch;
    }
    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }
}
