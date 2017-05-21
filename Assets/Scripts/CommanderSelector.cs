using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommanderSelector : MonoBehaviour {

    public static Commander controlledCommander;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (!UnitSpawner.isActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hitInfo = new RaycastHit();
                bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
                if (hit)
                {
                    if (hitInfo.transform.gameObject.tag == "Commander")
                    {
                        if (CommanderSelected()) ReleaseCommander();
                        SelectCommander(hitInfo);
                    }
                    else
                    {
                        if (controlledCommander != null)
                        {
                            ReleaseCommander();
                        }

                    }
                }
                else
                {
                    controlledCommander = null;
                }
            }
        }
        
    }

    private void ReleaseCommander ()
    {
        controlledCommander.isSelected = false;
        controlledCommander = null;
    }

    private bool CommanderSelected ()
    {
        return (controlledCommander != null);
    }

    private void SelectCommander(RaycastHit hit)
    {
        controlledCommander = hit.transform.gameObject.GetComponent<Commander>();
        controlledCommander.isSelected = true;
    }

}
