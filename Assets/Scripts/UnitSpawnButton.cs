using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawnButton : MonoBehaviour {

    public Unit unit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SelectUnitToSpawn ()
    {
        UnitSpawner.selectedUnit = unit;
    }
}
