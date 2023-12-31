﻿//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    [Header("Game Over Ui Canvas Object")]
    public GameObject platform;
    public float pos = 0;
    [Header("Game Over UI Canvas Object")]
    public GameObject gameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 1000; i++)
        {
            SpawnPlatforms();
        }
    }
    
    void SpawnPlatforms()
    {
        Instantiate(platform, new Vector3(UnityEngine.Random.value * 10 - 5f, pos, 0.5f), Quaternion.identity);
        pos += 5f;
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
    }

}