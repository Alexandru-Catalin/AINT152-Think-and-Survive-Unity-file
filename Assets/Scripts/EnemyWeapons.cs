using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapons : MonoBehaviour {

    public float fireRate = 0.5f;
    private bool canFire = true;

    public float smoothing = 5.0f;

    public Transform target;


    public GameObject enemyAttackPrefab;
    public GameObject attackSpawn;
	public GameObject attackSpawn2;

    public float adjustmentAngle;

    void Start()
    {
        //Invoke("Fire", fireRate);
    }


	// Use this for initialization
	void Fire () {
		Instantiate(enemyAttackPrefab, attackSpawn.transform.position, attackSpawn.transform.rotation);
		Instantiate (enemyAttackPrefab, attackSpawn2.transform.position, attackSpawn2.transform.rotation);
        //Invoke("Fire", fireRate);
        canFire = true;
	}
	
	// Update is called once per frame
	void Update () {
        if(target != null && canFire)
        {
            canFire = false;
            Invoke("Fire", fireRate);
        }

        else
        {
            if(target != null)
            {
                Vector3 difference = target.position - transform.position;
                difference.Normalize();

                float rotZ = (Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg) + adjustmentAngle;

                Quaternion newRot = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotZ));
                
                transform.rotation = Quaternion.Lerp(transform.rotation, newRot, Time.deltaTime * smoothing);
            }
        }
		
	}

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
    
}
