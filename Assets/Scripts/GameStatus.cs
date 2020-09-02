﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour{

    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 10;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] int currentScore = 0; //Serialized for debugging

    void Awake(){
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if(gameStatusCount > 1){
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start(){
        scoreText.text = "Score: " + currentScore;
    }
    // Update is called once per frame
    void Update(){
        Time.timeScale = gameSpeed;
    }

    public void AddToScore(){
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = "Score: " + currentScore;
    }
}