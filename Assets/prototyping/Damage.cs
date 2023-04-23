using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
  
    private Health health;
    // Start is called before the first frame update
    void Start()
    {

        health = GetComponent<Health>();
        Debug.Log(health);
   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Mouseclick");
            Debug.Log(health.m_CurrentHealth);
            health.Damage(1f);
         
        }
    }
}
