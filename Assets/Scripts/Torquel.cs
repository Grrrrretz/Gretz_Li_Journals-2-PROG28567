using UnityEngine;

public class Torquel : MonoBehaviour
{

    public Rigidbody2D rigidbody2;

    private bool IsActive = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            IsActive = true;
        }
    }

    void FixedUpdate()
    {
        if (IsActive == true)
        {
            rigidbody2.AddTorque(10, ForceMode2D.Impulse);
            IsActive = false;

        }
        
    }
}
