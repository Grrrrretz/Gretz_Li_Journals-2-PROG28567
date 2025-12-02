using UnityEngine;

public class JumpPad : MonoBehaviour
{

    public float jumpSpeed;

    public LayerMask playerLayer;






    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((playerLayer.value & (1 << collision.gameObject.layer)) != 0)//https://discussions.unity.com/t/checking-if-a-layer-is-in-a-layer-mask/860331/7  use idea in this post of how to set condition
        {
            Rigidbody2D player = collision.GetComponent<Rigidbody2D>();

            Vector2 playerspeed = player.linearVelocity;

            if (playerspeed.y < jumpSpeed)
            {
                playerspeed.y = jumpSpeed;
            }

            player.linearVelocity = playerspeed;
        }
       
    }
}
