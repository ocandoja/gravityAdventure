using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Create an enumeration to save the game states
public enum GameState
{
  menu,
  inGame,
  gameOver
}

public class GameManager : MonoBehaviour
{
  public GameState currentGameState = GameState.menu;
  // Singleton
  public static GameManager sharedInstance;
  private PlayerController controller;
  public int collectedObjects = 0;
  private void Awake()
  {
    if (sharedInstance == null)
    {
      sharedInstance = this;
    }
  }
  // Start is called before the first frame update
  void Start()
  {
    controller = GameObject.Find("Player").GetComponent<PlayerController>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetButtonDown("Submit") && currentGameState != GameState.inGame)
    {
      StartGame();
    }
  }
  public void StartGame()
  {
    SetGameState(GameState.inGame);
    GetComponent<AudioSource>().Play();
  }
  public void GameOver()
  {
    SetGameState(GameState.gameOver);
  }
  public void BackToMenu()
  {
    SetGameState(GameState.menu);
  }
  private void SetGameState(GameState newGameState)
  {
    if (newGameState == GameState.menu)
    {
      //menu logic
      MenuManager.sharedInstance.ShowMainMenu();
      MenuManager.sharedInstance.HideGameMenu();
      MenuManager.sharedInstance.HideGameOverMenu();
    }
    else if (newGameState == GameState.inGame)
    {
      //preparate scene
      LevelManager.sharedInstance.RemoveAllLevelBlocks();
      LevelManager.sharedInstance.GenerateInitialBlocks();
      controller.StartGame();
      MenuManager.sharedInstance.HideMainMenu();
      MenuManager.sharedInstance.ShowGameMenu();
      MenuManager.sharedInstance.HideGameOverMenu();
    }
    else if (newGameState == GameState.gameOver)
    {
      //game over
      MenuManager.sharedInstance.HideMainMenu();
      MenuManager.sharedInstance.HideGameMenu();
      MenuManager.sharedInstance.ShowGameOverMenu();
    }
    this.currentGameState = newGameState;
  }
  public void CollectObject(Collectable collectable)
  {
    collectedObjects += collectable.value;
  }
}
