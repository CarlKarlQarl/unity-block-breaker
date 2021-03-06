﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    [SerializeField] int breakableBlocks; //Serialized for debugging
    SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start(){
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    // Update is called once per frame
    void Update(){}

    public void CountBlocks(){
        breakableBlocks++;
    }

    public void BlockDestroyed(){
        breakableBlocks--;
        if (breakableBlocks <= 0){
            sceneLoader.LoadNextScene();
        }
    }
}
