using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDimensionalBlendAnim : MonoBehaviour
{
    Animator animator;
    float velocityX = 0f;
    float velocityZ = 0f;
    public float acceleration = 2f;
    public float decceleration = 2f;
    float maxWalkVelocity = 0.5f;
    float maxRunVelocity = 2f;
    int velocityXHash, velocityZHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool forward = Input.GetKey(KeyCode.W);
        bool run = Input.GetKey(KeyCode.LeftShift);
        bool left = Input.GetKey(KeyCode.A);
        bool right = Input.GetKey(KeyCode.D);

        float currentMaxVelocity = run ? maxRunVelocity : maxWalkVelocity;

        if (forward && velocityZ < currentMaxVelocity)
        {
            velocityZ += Time.deltaTime * acceleration;
        }
        if (left && velocityX > -currentMaxVelocity)
        {
            velocityX -= Time.deltaTime * acceleration; 
        }
        if (right && velocityX < currentMaxVelocity)
        {
            velocityX += Time.deltaTime * acceleration;
        }
        if (!forward && velocityZ > 0f)
        {
            velocityZ -= Time.deltaTime * decceleration;
        }
        if (!forward && velocityZ < 0f)
        {
            velocityZ = 0f;
        }
        if (!left && velocityX < 0f)
        {
            velocityX += Time.deltaTime * decceleration;
        }
        if (!right && velocityX > 0f)
        {
            velocityX -= Time.deltaTime * decceleration;
        }
        if(!left && !right && velocityX != 0f && (velocityX < 0.05f && velocityX > -0.05f))
        {
            velocityX = 0f;
        }

        animator.SetFloat("velocity x", velocityX);
        animator.SetFloat("velocity z", velocityZ);
    }
}
