using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit2D : MonoBehaviour {
    public int damage = 10;
    public string damageTag = "";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(damageTag))
        {
            other.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
        }

        Destroy(gameObject);
    }
}
