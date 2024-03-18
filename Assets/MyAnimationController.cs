using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAnimationController : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    float velocity = 0f;
    float acceleration = 0.1f;
    float decceleration = .5f;
    int velocityHash;
    int isWalkingHash = Animator.StringToHash("isWalking");
    int isRunningHash = Animator.StringToHash("isRunning");
    void Start()
    {
        animator = GetComponent<Animator>();
        velocityHash = Animator.StringToHash("velocity");
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool("isWalking");
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool isRunning = animator.GetBool("isRunning");
        bool runningPressed = Input.GetKey(KeyCode.R);
        //if (!isWalking && forwardPressed)
        //{
        //    animator.SetBool(isWalkingHash, true);
        //}
        //if (isWalking && !forwardPressed)
        //{
        //    animator.SetBool(isWalkingHash, false);
        //}
        //if (!isRunning && runningPressed)
        //{
        //    animator.SetBool(isRunningHash, true);
        //}
        //if (isRunning && !runningPressed)
        //{
        //    animator.SetBool(isRunningHash, false);
        //}

        if (forwardPressed && velocity < 2f)
        {
            velocity += Time.deltaTime * acceleration;
            
        }
        if (!forwardPressed && velocity > 0f)
        {
            velocity -= Time.deltaTime * decceleration;
        }
        animator.SetFloat(velocityHash, velocity);
    }
}