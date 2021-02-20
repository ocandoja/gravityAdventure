using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Player movement variables
    public float jumpForce = 6f;
    Rigidbody2D rigidBody;
    //Animation variable to change the state
    Animator animator;
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
        animator.SetBool(STATE_ALIVE, true);
        animator.SetBool(STATE_ON_THE_GROUND, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }
        animator.SetBool(STATE_ON_THE_GROUND, isItGrounded());

        Debug.DrawRay(this.transform.position, Vector2.down * 1.5f, Color.blue);
    }
    
    void Jump(){
        if(isItGrounded()){
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    //Know if the character is touching the ground
    bool isItGrounded(){
        if(Physics2D.Raycast(this.transform.position, Vector2.down, 1.4f, groundMask)){
            //Create logic of contact to the floor
            animator.enabled = true;
            return true;
        }else{
            //Create logic of not contact to the floor
            animator.enabled = false;
            return false;
        }
    }
}
