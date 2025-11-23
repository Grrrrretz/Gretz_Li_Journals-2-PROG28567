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


    public float ApexHeight;
    public float ApexTime;
    public float TerminalSpeed;
    public float CoyoteTime;
    //
    public float G;
    public float InitialJumpVelocity;
    private float CoyoteTimer;

    bool Jumping = false;




    public enum FacingDirection
    {
        left, right
    }

    // Start is called before the first frame update
    void Start()
    {

        acc = maxSpeed / accTime;
        dec = maxSpeed / decTime;

        G = -2f * ApexHeight / (ApexTime * ApexTime);
        InitialJumpVelocity = 2f * ApexHeight / ApexTime;

    }

    // Update is called once per frame
    void Update()
    {



        //The input from the player needs to be determined and then passed in the to the MovementUpdate which should
        //manage the actual movement of the character.

        if (Input.GetKey(KeyCode.D))
        {
            tool = 1;
            playerInput = new Vector2(tool, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            tool = -1;
            playerInput = new Vector2(tool, 0);
        }
        else
        {
            playerInput = Vector2.zero;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jumping = true;
        }

        if (IsGrounded())
        {
            CoyoteTimer = CoyoteTime;
        }
        else
        {
            CoyoteTimer -= Time.deltaTime;
        }

    }

    private void FixedUpdate()
    {



        MovementUpdate(playerInput);


    }

    private void MovementUpdate(Vector2 playerInput)
    {
        float realspeed = playerInput.x * maxSpeed;

        Vector2 nowspeed = rigibd.linearVelocity;

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

        float newSpeed = Mathf.MoveTowards(nowspeed.x, realspeed, ADDorSUB * Time.fixedDeltaTime);



        rigibd.linearVelocityX = newSpeed;

        rigibd.linearVelocityY += G * Time.fixedDeltaTime;

        if(Jumping == true && CoyoteTimer > 0f)
        {

            rigibd.linearVelocityY = InitialJumpVelocity;
            CoyoteTimer = 0f;

            
        }


        Jumping = false;


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

        if (Mathf.Abs(rigibd.linearVelocityY) < 0.01f)
        {
            return true;
        }
        else
        {
            return false;
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
