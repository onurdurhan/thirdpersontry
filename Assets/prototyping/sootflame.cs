using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sootflame : MonoBehaviour
{
    private ParticleSystem ps;
 
    // Start is called before the first frame update
    void Start()
    {
    
        ps = GetComponent<ParticleSystem>();


        ps.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Mouseclick");

            ps.Play();
        }

        if (Input.GetMouseButton(2))
        { ps.Stop(); }
    }
}
