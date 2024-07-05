using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BusketCollition : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject scorezonePrefab;
    private TextMeshPro textMeshPro;
    public double basketScoreMultiplier;
    public string targetTag = "basket";
    public string textValue;

    void Start()
    {
        textMeshPro = GetComponentInChildren<TextMeshPro>();
        if (textMeshPro == null)
        {
            Debug.Log("component not found");
            return;
        }
        textMeshPro.text = textValue;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.AddSore(basketScoreMultiplier);
        gameManager.UpdadeScore();
        if (collision.gameObject.CompareTag(targetTag))
        {
            Destroy(gameObject);
        }
    }

    public void SetMultiplier(double newNumber)
    {
        basketScoreMultiplier = Math.Round(newNumber,2);
        SetText(basketScoreMultiplier.ToString());
    }

    public void SetText(string newText)
    {
        textValue = "x"+newText;
        if (textMeshPro != null)
        {
            textMeshPro.text = "x"+textValue;
        }
    }

    

}
