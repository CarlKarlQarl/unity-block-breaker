using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour{

    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 10;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    [SerializeField] int currentScore = 0; //Serialized for debugging

    void Awake(){
        int GameSessionCount = FindObjectsOfType<GameSession>().Length;
        if(GameSessionCount > 1){
            gameObject.SetActive(false);
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

    public void ResetGame(){
        gameObject.SetActive(false);
        Destroy(gameObject);       
    }

    public bool IsAutoPlayEnabled(){
        return isAutoPlayEnabled;
    }
}