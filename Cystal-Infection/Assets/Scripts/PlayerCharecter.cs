using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerCharecter : MonoBehaviour
{

    [Header("Player Variables")]
    public bool isFaceRight = true;
    public float playerHP = 100;
    private const float horSpeed = 0.5f;
    private const float verSpeed = 0.5f;
    
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private FixedJoystick fixedJoystick;
    Rigidbody2D rb;
    Animator animator;
   
    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
       
    }
    void Update()
    {
        // MainCamera Moving
        mainCamera.transform.position = new Vector3(transform.position.x * 1f, transform.position.y * 1f, mainCamera.transform.position.z);

        //Player Moving
       rb.velocity = new Vector2(fixedJoystick.Horizontal * horSpeed , fixedJoystick.Vertical * verSpeed );  

        //Animation
        if (fixedJoystick.Horizontal != 0 || fixedJoystick.Vertical != 0)
        {
            animator.SetBool("Running", true);
        }
        else if(fixedJoystick.Horizontal == 0 || fixedJoystick.Vertical == 0)
        {
            animator.SetBool("Running", false);
        }

        //CheckWhereToFace

        if (!isFaceRight && fixedJoystick.Horizontal > 0) 
        {
            Flip();
           
        }
           
         if (isFaceRight && fixedJoystick.Horizontal < 0)
        {
            Flip();
        }
    }
    void Flip()
    {
        isFaceRight = !isFaceRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

       
       
    }
    
}
