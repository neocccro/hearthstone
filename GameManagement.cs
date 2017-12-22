
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour {


    public Queue<CallQueueObject> funcQueue = new Queue<CallQueueObject>();   

	// Use this for initialization
	void Start()
    {
    }
	
	// Update is called once per frame
	void Update()
    {
        if (funcQueue.Count > 0)
        {
            if(funcQueue.Peek().Check())
            {
                funcQueue.Dequeue();
            }
        }
	}
}

public class CallQueueObject
{
    private Vector3 targetPos;
    private Func<Vector3, bool> function;

    public CallQueueObject(Vector3 inputVector3, Func<Vector3,bool> inputFunc)
    {
        targetPos = inputVector3;
        function = inputFunc;
    }

    public bool Check()
    {
        return function(targetPos);
    }
}