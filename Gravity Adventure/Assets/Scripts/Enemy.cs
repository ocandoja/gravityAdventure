using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public float runningSeed = 1.5f;
  public int enemyDamage = 10;
  Rigidbody2D rigidBody;
  public bool facingRight = false;
  private Vector3 startPosition;
  private void Awake()
  {
    rigidBody = GetComponent<Rigidbody2D>();
    startPosition = this.transform.position;
  }
  // Start is called before the first frame update
  void Start()
  {
    this.transform.position = startPosition;

  }
  // Update is called once per frame
  void Update()
  {

  }
  private void FixedUpdate()
  {
    float currentRunningSpeed = runningSeed;
    if (facingRight)
    {
      // looking to the right
      currentRunningSpeed = runningSeed;
      this.transform.eulerAngles = new Vector3(0, 180, 0);
    }
    else
    {
      // looking to the left
      currentRunningSpeed = -runningSeed;
      this.transform.eulerAngles = Vector3.zero;
    }
    if (GameManager.sharedInstance.currentGameState == GameState.inGame)
    {
      rigidBody.velocity = new Vector2(currentRunningSpeed, rigidBody.velocity.y);
    }
  }
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Coin")
    {
      return;
    }
    if (other.tag == "Player")
    {
      other.gameObject.GetComponent<PlayerController>().CollectHealth(-enemyDamage);
      return;
    }
    //If we get until this point it is probably enemy did not hit the player or a coin
    //In that case here will be an other enemy or the land
    //* lets make the enemy flip
    facingRight = !facingRight;
  }
}
