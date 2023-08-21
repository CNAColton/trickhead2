using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine.UI;
using UnityEngine;


public class PlayerControls : MonoBehaviour
    {    //varible equals to component Rigidbody2D
    [Header("Rigidbody")]
    public Rigidbody2D rb;
    [Header("Defalt Down speed")]
    //downward speed of the object
    public float downSpeed = 20f;
    // Update is called once per frame
    private float movement;
    public float movementSpeed;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

 void Update()
    {   
        //movement equals Horizontal movement
        //multiplied by the movement speed 
        movement = Input.GetAxis("Horizontal") * movementSpeed;
        //if direction on x axis is less than 0
        if (movement < 0)
        {
            //object faces to the left
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        //if direction on x axis is greater than 0
        else
        {
            //object faces to the right
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        //If the players velocity is greater than 0
        //and position on the y axis is greater
        //than the score
        if (rb.velocity.y > 0 && transform.position.y > topScore)
        {
            //Score equals players position
            topScore = transform.position.y;

        }
        //Text for the score equals to the top score
        scoreText.text = "Score: " + Mathf.Round(topScore).ToString();
    }
    //Fixedupdate called every fixed frame-rate frame
    void FixedUpdate()
    {
        //Vector2 which is (x,y) velocity
        //equals to the velocity of the rigidbody2D
        Vector2 velocity = rb.velocity;
        //Velocity of the x axis equals to
        //the direction movement on the x axis
        //of the character.
        velocity.x = movement;
        //Rigidbody2D velocity equals to
        //velocity of the object
        rb.velocity = velocity;
    }
    //Collision function
     void OnCollisionEnter2D(Collision2D collision)
    {
        //velocity with the downspeed
        rb.velocity = new Vector3(rb.velocity.x, downSpeed, 0);
    }
    [Header("Score Text")]
    public Text scoreText;

    //score of the game
    private float topScore = 0.0f;
}