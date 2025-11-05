using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{

    public bool Active = false;

    public Collider2D ColliderA;
    public Collider2D ColliderB;

    public SpriteRenderer Renderer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreCollision(ColliderA, ColliderB, Active);

        if (Physics2D.GetIgnoreCollision(ColliderA, ColliderB))
        {
            Renderer.color = Color.white;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("i'm colliding");

        Renderer.color = Color.red;
    }
}
