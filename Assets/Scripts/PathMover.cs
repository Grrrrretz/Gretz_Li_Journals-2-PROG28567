using UnityEngine;

public class PathMover : MonoBehaviour
{

    public Vector3 startposition,endposition;
    public Transform startHolder,endHolder;

    public float duration;
    public float timeMoving = 0f;

    public enum State
    {
        forwer,backward
    }

    public State currentState = State.forwer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeMoving += Time.deltaTime;

        if(currentState == State.forwer)
        {
            transform.position = Vector3.Lerp(startHolder.position, endHolder.position, timeMoving / duration);
        }else if(currentState == State.backward)
        {
            transform.position = Vector3.Lerp(endHolder.position, startHolder.position,  timeMoving / duration);
        }

        if(timeMoving >= duration)
        {
            if(currentState == State.forwer)
            {
                currentState = State.backward;
            }
            else if(currentState == State.backward)
            {
                currentState = State.forwer;
            }
            timeMoving = 0f;
        }


    }
}
