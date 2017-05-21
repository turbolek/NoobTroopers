using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour {

    public Commander commander = null;
    public float movementSpeed = 9f;
    public float distanceToCommanderLimit = 15f;

	void Update () {
        if (commander == null && FindObjectOfType<Commander>() != null)
        {
            commander = findClosestCommander();
        }
		if (commander != null && getDistanceToCommander() >= distanceToCommanderLimit)
        {
            FollowCommander();
        }
	}

    float getDistanceToCommander ()
    {
        float distance = Mathf.Abs(Vector3.Distance(transform.position, commander.transform.position));
        return distance;
    }

    void MoveForward ()
    {
        float distance = Time.deltaTime * movementSpeed;
        transform.position += transform.forward * distance;
    }

    void FollowCommander()
    {
        transform.LookAt(commander.transform, Vector3.up);
        MoveForward();
    }


    Commander findClosestCommander()
    {
        Commander[] commanders = FindObjectsOfType<Commander>();
        Commander closestCommander = commanders[0];
        float closestDistance = (Vector3.Distance(transform.position, closestCommander.transform.position));
        foreach (Commander currentCommander in commanders)
        {
            float currentDistance = (Vector3.Distance(transform.position, currentCommander.transform.position));
            if (currentDistance < closestDistance) {
                closestDistance = currentDistance;
                closestCommander = currentCommander;
            } 
        }
        return closestCommander;
    }
}
