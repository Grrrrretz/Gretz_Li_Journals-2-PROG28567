using UnityEngine;

public class Plane : MonoBehaviour
{
    public Rigidbody2D planerigidbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //planerigidbody.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        //planerigidbody.AddForce(-Vector3.up, ForceMode2D.Force);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("this object has just collided");
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("this obj is staying");
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("this obj is stop cpllided");
    }
}
