using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BarrierAnimation : MonoBehaviour
{
    private String[] animations = {"Anim1", "Anim2", "Anim3"};
    
    public void OnAnimationStop()
    {
        var animator = GetComponent<Animator>();

        var rand = Random.Range(0, 3);
        
        animator.SetInteger("AnimIndex", rand);
    }
}
