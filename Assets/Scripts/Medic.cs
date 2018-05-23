using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medic : MonoBehaviour {

    public int amount = 10;

	void Start () {
		
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);  // Destroys Health Box
            print("Gained 10 Health");
            other.transform.SendMessage("TakeDamage", -amount, SendMessageOptions.DontRequireReceiver);
        }

    }
}
