using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour {

    public static Unit selectedUnit;
    public static bool isActive = false;

    private Transform unitPrefab;

	void Update () {
        if (selectedUnit != null)
        {
            isActive = true;
            unitPrefab = selectedUnit.gameObject.transform;
            SpawnOnMouseClick();
        } else
        {
            isActive = false;
        }
         
	}

    private void SpawnUnit ()
    {
        Instantiate(unitPrefab, MousePositionToWorld(), Quaternion.identity);
        selectedUnit = null;
    }

    private void CancelSelection()
    {
        selectedUnit = null;
    }

    private void SpawnOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0)) {
            SpawnUnit();
        }

        if (Input.GetMouseButtonDown(1))
        {
            CancelSelection();
        }
    }

    private Vector3 MousePositionToWorld()
    {
        Vector3 mousePosition = Input.mousePosition;
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            mousePosition = hit.point;
            mousePosition.y += 1.5f;
        }
            
        return mousePosition;
    }

}
