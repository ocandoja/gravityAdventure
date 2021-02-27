using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    public Text coinsText, scoreText, maxText;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
       if(GameManager.sharedInstance.currentGameState == GameState.inGame){
           int coins = 0;
           float score = 0f;
           float maxScore = 0f;
           coinsText.text = coins.ToString();
           scoreText.text = score.ToString("f1");
           maxText.text = maxScore.ToString("f1");
       } 
    }
}
