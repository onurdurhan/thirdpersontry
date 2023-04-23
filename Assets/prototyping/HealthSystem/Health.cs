using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public float startingHealth = 100f;
    public float m_CurrentHealth { get; set; }
    public Vector3 Position
    {
        get
        {
            return transform.position;
        }
    }
    void Start()
    {
        m_CurrentHealth = startingHealth;
    }
    public void Damage(float damage)
    {
        m_CurrentHealth -= damage;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
