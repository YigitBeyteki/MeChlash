using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W)) 
        {
            animator.SetBool("isRunning", true);
            transform.Translate(new Vector3(0, 0, 2f) * Time.deltaTime);

        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetBool("isAttacking", true);
            

        }
        else
        {
            animator.SetBool("isAttacking", false);
        }

    }


   
}
