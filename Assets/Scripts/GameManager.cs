using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ballCostText;
    public float ballValue = 10f;
    public float startingScore = 1000f;
    public double score = 1000f;
    public GameObject redBallPrefab;
    public float startY = 2.5f;

    void Start()
    {
        RestartGame();
        UpdadeScore();
        UpdateBallCostText();
    }

    public void UpdadeScore()
    {
        scoreText.text = score.ToString();
    }

    public void UpdateBallCostText()
    {
        ballCostText.text = "Bet:" + ballValue.ToString();
    }
    public void AddSore(double multiplier)
    {
        score += ballValue * multiplier;
        
    }

    public void RemoveScore()
    {
        score -= ballValue;
        UpdadeScore();
    }

    public void SetBallValue(float newValue)
    {
        ballValue = newValue;
    }

    float RandomXCoordinates()
    {
        return Random.Range(-0.2f, 0.2f);
    }

    public void SpawnRedBall()
    {
        if (score >= ballValue)
        {
            Vector3 position = new Vector3(RandomXCoordinates(), startY, -1);
            Instantiate(redBallPrefab, position, Quaternion.identity);
            BuyBall();
            UpdadeScore();
        } else
        {
            Debug.Log("Not Enough money");
        }
    }

    public void BuyBall()
    {
        RemoveScore();
        UpdadeScore();
    }

    public void RestartGame()
    {
        score = startingScore;
        UpdadeScore();
    }

    public void DecreaseCost()
    {
        if (ballValue != 10)
        {
            ballValue /= 2;
            UpdateBallCostText();
        }
    }

    public void IncreaseCost()
    {
        if (ballValue < 640)
        {
            ballValue *= 2;
            UpdateBallCostText();
        }
    }
}
