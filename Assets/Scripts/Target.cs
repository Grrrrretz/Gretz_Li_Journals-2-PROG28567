using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Target : MonoBehaviour
{
    public ScoreboardController controller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        CannonballController cannonball = collision.gameObject.GetComponent<CannonballController>();
        if (cannonball != null)
        {
            controller.Score += 1;
        }


    }
}
