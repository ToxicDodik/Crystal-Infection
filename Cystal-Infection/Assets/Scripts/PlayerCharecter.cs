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
    private const float horSpeed = 0.5f;
    private const float verSpeed = 0.5f;

    [Header("Player Links")]

    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private FixedJoystick fixedJoystick;

    PC_Android_Switcher PC_Android_Swticher = new PC_Android_Switcher(); 

    Rigidbody2D rb;
    Animator animator;

    private bool isControlTypeAndroid;
    private bool isControlTypePC;

    void Start()
    {
        isControlTypeAndroid = PC_Android_Swticher.IsAndroid;
        isControlTypePC = PC_Android_Swticher.IsPC;

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
       
    }
    void Update()
    {
        Debug.Log(isControlTypePC);
        // MainCamera Moving
        mainCamera.transform.position = new Vector3(transform.position.x * 1f, transform.position.y * 1f, mainCamera.transform.position.z);
        // PlayerController PC version
        if (isControlTypePC == true)
        {
            //Moving && Animation
            var hor = Input.GetAxis("Horizontal");
            var ver = Input.GetAxis("Vertical");

            if (Mathf.Abs(hor) > 0 || Mathf.Abs(ver) > 0)
            {
                rb.velocity = new Vector2(hor * horSpeed, ver * verSpeed);
                if (hor != 0 || ver != 0)
                {
                    animator.SetBool("Running", true);
                }
            }
            else if (hor == 0 || ver == 0)
            {
                animator.SetBool("Running", false);
            }
            //CheckWhereToFace
            if (!isFaceRight && hor > 0)
            {
                Flip();

            }
            else if (isFaceRight && hor < 0)
            {
                Flip();
            }
        }
        //PlayerController Android Version
        else if(isControlTypeAndroid == true)
        {
            //Moving Animation
           
                rb.velocity = new Vector2(fixedJoystick.Horizontal * horSpeed, fixedJoystick.Vertical * verSpeed);
                animator.SetBool("Running", true);
            
            if (fixedJoystick.Horizontal == 0 || fixedJoystick.Vertical == 0)
            {
                animator.SetBool("Running", false);
            }

            //CheckWhereToFace
            if (!isFaceRight && fixedJoystick.Horizontal > 0)
            {
                Flip();
            }
            else if (isFaceRight && fixedJoystick.Horizontal < 0)
            {
                Flip();
            }
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
