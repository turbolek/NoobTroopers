using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float cameraMovementSpeed = 10f;
    public float cameraScrollSpeed = 50f;
    public float cameraXOffset = 43;

    private Camera camera;

	// Use this for initialization
	void Start () {
        camera = GetComponent<Camera>();
	}

    // Update is called once per frame
    void Update()
    {
        if (CommanderSelector.controlledCommander != null)
        {
            FollowCommander();
        } else
        {
            HandleMovement();
        }
        
        HandleZoom();
    }

    private void HandleMovement()
    {
        float distance = Time.deltaTime * cameraMovementSpeed;
        float newX = transform.position.x;
        float newZ = transform.position.z;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            newZ += distance;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            newZ += -distance;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            newX += distance;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            newX += -distance;
        }

        newX = Mathf.Clamp(newX, 0f, 500f);
        newZ = Mathf.Clamp(newZ, 0f, 500f);

        transform.position = new Vector3(newX, transform.position.y, newZ);
    }

    private void HandleZoom()
    {
        float newFieldOfView = camera.fieldOfView;
        float fieldOfFievShift = cameraScrollSpeed * Time.deltaTime;
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            newFieldOfView += fieldOfFievShift;

        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            newFieldOfView -= fieldOfFievShift;
        }
        newFieldOfView = Mathf.Clamp(newFieldOfView, 10, 70);
        camera.fieldOfView = newFieldOfView;
    }

    private void FollowCommander()
    {
        float newX = CommanderSelector.controlledCommander.transform.position.x + cameraXOffset;
        float newZ = CommanderSelector.controlledCommander.transform.position.z;
        transform.position = new Vector3(newX, transform.position.y, newZ);
    }
}


