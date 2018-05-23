using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public int damage = 10;
    void Start()
    {
        //Destroy(gameObject, 0.5f);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        other.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
    }
}
