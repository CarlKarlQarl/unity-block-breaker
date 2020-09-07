using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour{

    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;

    Level level;
    GameSession GameSession;

    // Start is called before the first frame update
    void Start(){
        level = FindObjectOfType<Level>();
        GameSession = FindObjectOfType<GameSession>();
        level.CountBreakableBlocks();
    }
    // Update is called once per frame
    void Update(){}

    private void OnCollisionEnter2D(Collision2D collision) {
        DestroyBlock();
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
}
