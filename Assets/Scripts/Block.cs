﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour{

    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    Level level;
    GameSession GameSession;

    [SerializeField] int timesHit; //serialized for debugging

    // Start is called before the first frame update
    void Start(){
        level = FindObjectOfType<Level>();
        GameSession = FindObjectOfType<GameSession>();
        if(tag == "Breakable"){
            level.CountBlocks();
        }
    }
    // Update is called once per frame
    void Update(){}

    private void OnCollisionEnter2D(Collision2D collision) {
        if(tag == "Breakable"){
            HandleHit();
        }
    }

    private void DestroyBlock(){
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        TriggerSparklesVFX();
        level.BlockDestroyed();
        GameSession.AddToScore();
        Destroy(gameObject);
    }

    private void TriggerSparklesVFX(){
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform. rotation);
        Destroy(sparkles, 1f);
    }

    private void HandleHit(){
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if(timesHit >= maxHits){
            DestroyBlock();
        } else {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite(){
        int spriteIndex = timesHit - 1;
        if(hitSprites[spriteIndex] != null){
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        } else {
            Debug.LogError("Block sprite is missing from array: " + gameObject.name);
        }
        
    }
}
