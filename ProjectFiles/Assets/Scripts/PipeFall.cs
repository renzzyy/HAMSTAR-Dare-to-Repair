using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeFall : MonoBehaviour
{
    
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D col) 
    {
        Invoke("PlayAnimation", 0.25f);
    }

    void PlayAnimation()
    {
        animator.SetBool("IsFalling", true);
    }
    
}
