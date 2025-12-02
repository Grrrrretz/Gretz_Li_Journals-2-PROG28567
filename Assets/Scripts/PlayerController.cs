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
    public LayerMask GroundTile;


    public Vector2 playerInput;



    public Rigidbody2D rigibd;


    public float ApexHeight;
    public float ApexTime;
    public float TerminalSpeed;
    public float CoyoteTime;

    public float G;
    public float InitialJumpVelocity;
    public float CoyoteTimer;

    bool Jumping = false;

    //------------------------------------------------//
    public float jumpcutG = 2f;
    public float minJumpTime = 0.05f;

    bool jumpHolding = false;
    public float jumpHoldingTimer;
    //------------------------------------------------//
    public float DashSpeed = 10f;
    public float DashDuration = 0.15f;
    public float DashCD = 0.5f;
    //-----------------------------------------------//
    public float DashTimer;
    public float DashCDTimer;

    bool dashing = false;


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

        //walkPart----------------------------------
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
        //jumpPart-----------------------------------
   

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jumping = true;
            jumpHolding = true;
            jumpHoldingTimer = 0;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpHolding = false;
        }

        if (IsGrounded())
        {
            CoyoteTimer = CoyoteTime;
        }
        else
        {
            CoyoteTimer -= Time.deltaTime;
        }
        //Dashpart----------------------------------------
        if (DashCDTimer > 0f) 
        { 
        
            DashCDTimer -= Time.deltaTime;
        
        }
        if(dashing == true)
        {
            DashTimer -= Time.deltaTime;
            if(DashTimer <= 0)
            {
                dashing = false;
            }
        }else if(Input.GetKeyDown(KeyCode.LeftShift) && DashCDTimer <= 0f && playerInput.x != 0)
        {
            dashing = true;
            DashTimer = DashDuration;
            DashCDTimer = DashCD;
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

        

        //dashpart

        if(dashing == true)
        {
            float dashlocation = DashSpeed * playerInput.x;
            nowspeed.x = dashlocation;
        }



        //X axis final
        float newSpeed = Mathf.MoveTowards(nowspeed.x, realspeed, ADDorSUB * Time.fixedDeltaTime);



        rigibd.linearVelocityX = newSpeed;


        //jump part

        if (jumpHolding == true)
        {
            jumpHoldingTimer += Time.fixedDeltaTime;
        }


        float currentG = G;

        if (jumpHolding == false && nowspeed.y > 0 && jumpHoldingTimer >= minJumpTime)
        {
            currentG = G* jumpcutG;
        }

        nowspeed.y += currentG * Time.fixedDeltaTime;

        if (Jumping == true && CoyoteTimer > 0f)
        {

            nowspeed.y = InitialJumpVelocity;
            CoyoteTimer = 0f;

            
        }
        if (rigibd.linearVelocityY < -TerminalSpeed && TerminalSpeed > 0f)
        {
            nowspeed.y = -TerminalSpeed;
        }

        rigibd.linearVelocityY = nowspeed.y;

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

        if(Physics2D.Raycast(new Vector2(transform.position.x-0.5f,transform.position.y), Vector2.down, 0.7f, GroundTile) || Physics2D.Raycast(new Vector2(transform.position.x + 0.5f, transform.position.y), Vector2.down, 0.7f, GroundTile))
        {
            return true;
        }
        else
        {
            return false;
        }

        
        //


    }

    public FacingDirection GetFacingDirection()
    {

        if(tool > 0)
        {
            return FacingDirection.right;
        }
        else
        {
            return FacingDirection.left;
        }


        
        
    }
}
