using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMove : MonoBehaviour
{
    private short state;
    private float speed;
    private float slowdownSpeed;
    private float currentSpeed;
    private Vector3 targetPos;
    [SerializeField]
    private GameManagement gameManagement;

    // Use this for initialization
    void Start()
    {
        speed = 0.1f;
        currentSpeed = 1;
        targetPos = transform.position;
    }
	
	// Update is called once per frame

    public void stayStill()
    {
        state = 0;
    }
    public void stayStill(Vector3 targetPosition)
    {
        state = 0;
        goTo(targetPosition);
    }

    public void moveConsistent(Vector3 targetPosition)
    {
        state = 1;
        targetPos = targetPosition;
    }

    public void moveSpeeding(Vector3 targetPosition)
    {
        state = 2;
        targetPos = targetPosition;
        currentSpeed = 1;
    }

    public void moveSlowing(Vector3 targetPosition)
    {
        state = 3;
        targetPos = targetPosition;
    }

    public void goTo(Vector3 targetPosition)
    {
        transform.position = targetPosition;
        targetPos = targetPosition;
        stayStill();
    }
    
    private void consistentMove()
    {
        Vector3 move = Vector3.Min((transform.position - targetPos).normalized, (transform.position - targetPos));
        transform.position = transform.position + move;
    }

    private void speedMove()
    {
        Vector3 move = Vector3.Min((transform.position - targetPos).normalized, (transform.position - targetPos));
    }

    private void slowMove()
    {
        Vector3 move = Vector3.Min((transform.position - targetPos).normalized, (transform.position - targetPos));
    }
    


    private bool move(Vector3 targetPosition)
    {
        targetPos = targetPosition;
        Vector3 tmp = targetPos - transform.position;
        Vector3 tmp2 = tmp.normalized;
        transform.position += Shortest(tmp2 * speed, tmp);
        if(transform.position == targetPos)
        {
            state = 0;
            return true;
        }
        return false;
    }
    
    private Vector3 Shortest(Vector3 VectorA, Vector3 VectorB)
    {
        float A = Mathf.Pow(VectorA.x, 2) + Mathf.Pow(VectorA.y, 2) + Mathf.Pow(VectorA.z, 2);
        float B = Mathf.Pow(VectorB.x, 2) + Mathf.Pow(VectorB.y, 2) + Mathf.Pow(VectorB.z, 2);
        if(A < B)
        {
            return VectorA;
        }
        else
        {
            return VectorB;
        }
    }

    private void AddToQueue(Vector3 targetPosition)
    {
        gameManagement.funcQueue.Enqueue(new CallQueueObject(targetPosition, move));
    }
}
