using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commander : MonoBehaviour {

    public float movementSpeed;
    public float rotationSpeed;
    public float distanceToGoLimit;
    public float angleToRotateLimit;
    public bool isSelected = false;

    private float distanceCovered = 0f;
    private float distanceToGo = 0f;
    private bool readyToMove = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isSelected)
        {
            ControlledMovement();
        } else
        {
            RandomMovement();
        }
	}

    void MoveForward ()
    {
        float distance = Time.deltaTime * movementSpeed;
        transform.position += transform.forward * distance;
        distanceCovered += distance;        
    }

    void RandomRotate ()
    {
        float angle = Random.Range(angleToRotateLimit * (-1), angleToRotateLimit);
        transform.Rotate(transform.up, angle);
        readyToMove = true;
    }

    void RandomMovement()
    {
        if (readyToMove)
        {
            if (distanceCovered < distanceToGo)
            {
                MoveForward();
            } else
            {
                Stop();
            }
        } else
        {
            ChangeDirection();
        }
    }

    void Stop()
    {
        distanceCovered = 0;
        readyToMove = false;
    }

    void ChangeDirection()
    {
        RandomRotate();
        distanceToGo = Random.Range(0, distanceToGoLimit);
        readyToMove = true;
    }

    void ControlledMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            MoveForward();
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Rotate(-rotationSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Rotate(rotationSpeed);
        }

    }

    void Rotate(float rotationSpeed)
    {
        float angle = Time.deltaTime * rotationSpeed;
        transform.Rotate(transform.up, angle);
    }

}
