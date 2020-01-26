﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrayAnimatinController : MonoBehaviour
{
    public Animator Anim;
    public CarDrive Mag;

    private void Awake()
    {
        Anim.SetInteger("Run", 1);

    }
    void Update()
    {
        //Debug.Log(Mag.direction.magnitude);
        if (Mag.direction.magnitude < 10f)
        {
            //Anim.SetBool("Punch", true);
            Anim.SetInteger("Run", 0);
            
        }
        if(Mag.direction.magnitude > 10f)
        {
            Anim.SetBool("Punch", false);
            Anim.SetInteger("Run", 1);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Mag.enabled = false;
            Debug.Log("hh");
        }
    }
    void OnTriggerExit(Collider other)
    {
        Mag.enabled = true;
    }
}
