﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    [SerializeField] int breakableBlocks; //Serialized for debugging

    // Start is called before the first frame update
    void Start(){}
    // Update is called once per frame
    void Update(){}

    public void CountBreakableBlocks(){
        breakableBlocks++;
    }
}
