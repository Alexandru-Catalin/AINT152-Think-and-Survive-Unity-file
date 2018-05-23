using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {
    public GameObject objectPrefab;

	// Use this for initialization
	public void Spawn () {
        Instantiate(objectPrefab, transform.position, transform.rotation);
		
	}
	
}
