using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float acc;
    public float MAxspeed;


    public Vector2 playerInput;

    public Rigidbody2D rigibd;
    public enum FacingDirection
    {
        left, right
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //The input from the player needs to be determined and then passed in the to the MovementUpdate which should
        //manage the actual movement of the character.


        if (Input.GetKeyDown(KeyCode.D))
        {
            Vector2 playerInput = new Vector2(1, 0);
            MovementUpdate(playerInput);
        }else if (Input.GetKeyUp(KeyCode.D))
        {
            Vector2 playerInput = Vector2.zero;
            MovementUpdate(playerInput);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector2 playerInput = new Vector2(1, 0);
            MovementUpdate(playerInput);
        }


       
    }

    private void MovementUpdate(Vector2 playerInput)
    {

        rigibd.linearVelocityX = playerInput.x;



    }

    public bool IsWalking()
    {
        return false;
    }
    public bool IsGrounded()
    {
        return true;
    }

    public FacingDirection GetFacingDirection()
    {
        return FacingDirection.left;
    }
}
