using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _playerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController2D _controller;
    [SerializeField] private float speed = 35f;
    private float direction = 0f;
    private bool jump = false;

    public Animator animator;




    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

        

        direction = Input.GetAxisRaw("Horizontal") * speed;

        animator.SetFloat("run", Mathf.Abs(direction));

        if (Input.GetButton("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }
    }

    public void onLanding()
    {
        animator.SetBool("isJumping", false);
    }

    private void FixedUpdate()
    {
        
        
        _controller.Move(direction, false,  jump);
        


        jump = false;
    }

   
}
