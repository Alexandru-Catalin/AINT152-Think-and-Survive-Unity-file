using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectTimer : MonoBehaviour {
    public float spawnTime = 5.0f;

	// Use this for initialization
	void Start () {
        Invoke("DoSpawn", spawnTime);
		
	}
	
	// Update is called once per frame
	void DoSpawn () {
        SendMessage("Spawn");
        Invoke("DoSpawn", spawnTime);
		
	}
}
