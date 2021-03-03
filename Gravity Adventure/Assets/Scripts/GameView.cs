using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
  public Text coinsText, scoreText, maxText;
  private PlayerController controller;
  // Start is called before the first frame update
  void Start()
  {
    controller = GameObject.Find("Player").GetComponent<PlayerController>();
  }
  // Update is called once per frame
  void Update()
  {
    if (GameManager.sharedInstance.currentGameState == GameState.inGame)
    {
      int coins = GameManager.sharedInstance.collectedObjects;
      float score = controller.GetTravelledDistance();
      float maxScore = PlayerPrefs.GetFloat("maxscore", 0);
      coinsText.text = coins.ToString();
      scoreText.text = score.ToString("f1");
      maxText.text = maxScore.ToString("f1");
    }
  }
}
