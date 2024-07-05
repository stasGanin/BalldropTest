using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PinSpawner : MonoBehaviour
{
    
    public GameObject pinPrefab; 
    public GameObject scorezonePrefab;
    public int totalPins = 52; 
    public float pinSpacing = 0.4f; 
    public int layerScaling = 1; // pin count scaling each layer
    public int firstLayerPins = 3;
    public float startX = 0f; // better works with zero 
    public float startY = 2f;
    public float zlayer = -1; // layer management
    public float lowestMultiplier = 0.2f;

    void Start()
    {
        CreatePyramid();
    }

    void CreatePyramid()
    {
        int currentLayer = 1;
        int pinsPlaced = 0;
        int pinsInLayer = firstLayerPins;
        float currentX = startX - firstLayerPins/2* pinSpacing; //choose start point depends on 1 layer pun count

        while (pinsPlaced < totalPins) // create pins
        {
            
            for (int x = 0; x < pinsInLayer; x++)
            {
                if (pinsPlaced >= totalPins) break;

                Vector3 position = new Vector3(currentX + x * pinSpacing, startY - currentLayer * pinSpacing, zlayer); //choose new position
                Instantiate(pinPrefab, position, Quaternion.identity);  //create pin in this position 

                pinsPlaced++;
            }
            if (pinsPlaced < totalPins)
            {
                currentX -= pinSpacing / 2; //move line to create pyramid shape
                currentLayer++;
                pinsInLayer += layerScaling;
            }

            
        }

        int scorezonesToSpawn = pinsInLayer - 1;
        currentLayer++;
        float halfValue = scorezonesToSpawn / 2;
        double multiplier = lowestMultiplier * Math.Pow(2, halfValue);
        
        for (int i = 0; i < scorezonesToSpawn; i++)
        {
            Vector3 position = new Vector3(currentX + i * pinSpacing + pinSpacing / 2, startY - currentLayer * pinSpacing , zlayer);
            GameObject basket = Instantiate(scorezonePrefab, position, Quaternion.identity);
            basket.transform.localScale = new Vector3(pinSpacing * 2, pinSpacing * 2, 1); //scaling depends on spacing
            BusketCollition busketCollitionScript = basket.GetComponentInChildren<BusketCollition>();
            busketCollitionScript.SetMultiplier(multiplier);

            if (i< halfValue)
            {
                multiplier /= 2;
            }
            
            if (i >= halfValue)
            {
                multiplier *= 2;
            }
            

        }
        
    }

    
}
