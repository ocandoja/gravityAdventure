using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Player movement variables
    public float jumpForce = 6f;
    public float runnigSpeed = 2f;
    Rigidbody2D rigidBody;
    //Animation variable to change the state
    Animator animator;
    Vector3 startPosition;
    private const string STATE_ALIVE = "isAlive";
    private const string STATE_ON_THE_GROUND = "isGrounded";
    //Using layers to identify the floor
    public LayerMask groundMask;
    //Getting the variables on the awake
    private void Awake() {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.transform.position;
    }
    public void StartGame() {
        animator.SetBool(STATE_ALIVE, true);
        animator.SetBool(STATE_ON_THE_GROUND, true);
        Invoke("RestartPosition", 0.3f);
    }
    //Restare position and holder
    void RestartPosition(){
        this.transform.position = startPosition;
        this.rigidBody.velocity = Vector2.zero;
        GameObject gameCamera = GameObject.Find("Main Camera");
        gameCamera.GetComponent<CameraFollow>().ResetCameraPosition();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        animator.SetBool(STATE_ON_THE_GROUND, isItGrounded());
        Debug.DrawRay(this.transform.position, Vector2.down * 1.5f, Color.blue);
    }
    
    void Jump(){
        if(GameManager.sharedInstance.currentGameState == GameState.inGame){
            if(isItGrounded()){
                rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }
    void FixedUpdate() {
        if(GameManager.sharedInstance.currentGameState == GameState.inGame){
            if(rigidBody.velocity.x < runnigSpeed){
                rigidBody.velocity = new Vector2(runnigSpeed, rigidBody.velocity.y);
            }
        }else{//if we are not in game
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }
    }
    //Know if the character is touching the ground
    bool isItGrounded(){
        if(Physics2D.Raycast(this.transform.position, Vector2.down, 1.4f, groundMask)){
            return true;
        }else{
            return false;
        }
    }
    public void Die(){
        this.animator.SetBool(STATE_ALIVE, false);
        GameManager.sharedInstance.GameOver();
    }
}
