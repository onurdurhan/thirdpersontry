using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    private Rigidbody bulletRigidBody;

    private void Awake()
    {
        bulletRigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        float speed = 100f;
        bulletRigidBody.velocity = transform.forward * speed; 
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collided bullet");
        Destroy(gameObject,0.2f);
    }

}
