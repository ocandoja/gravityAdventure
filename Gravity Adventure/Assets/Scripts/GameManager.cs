using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Create an enumeration to save the game states
public enum GameState{
    menu,
    inGame,
    gameOver
}

public class GameManager : MonoBehaviour
{
    public GameState currentGameState = GameState.menu;
    // Singleton
    public static GameManager sharedInstance;
    private void Awake() {
        if(sharedInstance == null){
            sharedInstance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Submit")){
            StartGame();
        }
    }
    public void StartGame(){
        SetGameState(GameState.inGame);
    }
    public void GameOver(){
        SetGameState(GameState.gameOver);
    }
    public void BackToMenu(){
        SetGameState(GameState.menu);
    }
    private void SetGameState(GameState newGameState){
        if(newGameState == GameState.menu){
            //menu logic
        }else if(newGameState == GameState.inGame){
            //preparate scene
        }else if(newGameState == GameState.gameOver){
            //game over
        }
        this.currentGameState = newGameState;
    }
}
