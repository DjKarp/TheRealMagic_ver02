﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Off : MonoBehaviour
{

    public Animator Animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) Animator.SetTrigger("aaa");
    }
}
