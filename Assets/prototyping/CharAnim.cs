using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnim : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;
    private Health health;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
//        cc = GetComponent<MyCharController>();
//        health = GetComponent<Health>();
        
    }

    // Update is called once per frame
//    void Update()
//    {
    
       //Debug.Log(cc.Motor.BaseVelocity);
       //Debug.Log(cc.Motor.GroundingStatus.IsStableOnGround);
 //      if (Vector3.Magnitude(cc.Motor.BaseVelocity) > 0.0001 && cc.Motor.GroundingStatus.IsStableOnGround)
 //       { anim.SetBool("isRunning", true); }
        
 //      else
//        { anim.SetBool("isRunning", false); }
//        //Debug.Log("Run Param" + anim.GetBool("isRunning"));

//        if (health.m_CurrentHealth<0)
//        { anim.SetBool("isDead", true); }
      //  else
      //  { anim.SetBool("isDead", false); }

 //       if (Input.GetMouseButtonDown(0))
//        { anim.SetBool("isShooting", true);
           
 //       }
//        else
//        { anim.SetBool("isShooting", false);
//            
//        }


//    }
}
