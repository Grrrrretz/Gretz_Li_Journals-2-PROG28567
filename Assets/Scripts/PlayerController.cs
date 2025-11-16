using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float maxSpeed = 5f;
    public float accTime = 0.2f;
    public float decTime = 0.1f;
    public float acc;
    public float dec;
    public float tool;

    public bool moveRight = false;
    public bool moveLeft = false;


    public Vector2 playerInput;



    public Rigidbody2D rigibd;
    public enum FacingDirection
    {
        left, right
    }

    // Start is called before the first frame update
    void Start()
    {

        acc = maxSpeed / accTime;
        dec = maxSpeed / decTime;

    }

    // Update is called once per frame
    void Update()
    {



        //The input from the player needs to be determined and then passed in the to the MovementUpdate which should
        //manage the actual movement of the character.


        if (Input.GetKey(KeyCode.D))
        {
            moveRight = true;
            tool = 1;
            playerInput = new Vector2(tool, 0);
            rigibd.linearVelocityY = 0;

        }

        if (Input.GetKey(KeyCode.A))
        {
            moveLeft = true;
            tool = -1;
            playerInput = new Vector2(tool, 0);
            rigibd.linearVelocityY = 0;
        }

        Debug.Log("VY =" + rigibd.linearVelocityY);

    }

    private void FixedUpdate()
    {

        if (moveLeft == true)
        {
            
            MovementUpdate(playerInput);

            moveLeft = false;
        }
        else if (moveRight == true)
        {
            
            MovementUpdate(playerInput);
            moveRight = false;
        }




    }

    private void MovementUpdate(Vector2 playerInput)
    {
        float realspeed = playerInput.x * maxSpeed;

        float nowspeed = rigibd.linearVelocity.x;

        bool accING = false;

        if(Mathf.Abs(realspeed) != 0)
        {
            accING = true;
        }
        else
        {
            accING = false;
        }
        float ADDorSUB;


        if (accING == true)
        {
            ADDorSUB = acc;
        }
        else
        {
            ADDorSUB = dec;
        }

        float newSpeed = Mathf.MoveTowards(nowspeed, realspeed, ADDorSUB * Time.fixedDeltaTime);




        rigibd.linearVelocityX = newSpeed;



    }

    public bool IsWalking()
    {
        if (Mathf.Abs(rigibd.linearVelocityX) > 0)
        {
            return true;
        }
        else
        {
            return false;
        }

        

        
    }
    public bool IsGrounded()
    {
        if (Mathf.Abs(rigibd.linearVelocityY) !=0)
        {
            return false;
        }
        else
        {
            return true;
        }

        
        //return true;


    }

    public FacingDirection GetFacingDirection()
    {

        if(playerInput.x >= 0)
        {
            return FacingDirection.right;
        }
        else
        {
            return FacingDirection.left;
        }


        
        
    }
}
