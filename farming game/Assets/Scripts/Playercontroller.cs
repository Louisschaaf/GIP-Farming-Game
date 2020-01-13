﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class Playercontroller : MonoBehaviour
{
    [Header("character attributes:")]
    public float Speed = 1.0f;

    [Space]
    [Header("character statistics:")]
    public Vector2 movementDirection;
    public float movementspeed;

    [Space]
    [Header("references:")]
    public Rigidbody2D rb;
    public Animator animator;
    Lookstate lookstate { get; set; }
    bool Isactive = false   ;

    public Inventory inventory;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        Move();
        Animate();
    }

    void ProcessInputs()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementspeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();
        //gebruik mousebuttondown
        if (Input.GetMouseButtonDown(0))
        {
            Isactive = true;
        }
        if (lookstate == Lookstate.Back && Isactive == true)
        {
            Isactive = false;
            animator.SetTrigger("Back");
        }
        if (lookstate == Lookstate.Left && Isactive == true)
        {
            Isactive = false;
            animator.SetTrigger("Left");
        }
        if (lookstate == Lookstate.Right && Isactive == true)
        {
            Isactive = false;
            animator.SetTrigger("Right");
        }
        if (lookstate == Lookstate.Front && Isactive == true)
        {
            Isactive = false;
            animator.SetTrigger("Front");
        }
    }
    void Move()
    {
        rb.velocity = movementDirection * movementspeed * Speed;
    } 

    enum Lookstate
    {
        Front,
        Back,
        Left,
        Right
    }

    void Animate()
    {
       
        animator.SetFloat("Horizontal", movementDirection.x);
        animator.SetFloat("Vertical", movementDirection.y);
        animator.SetFloat("Speed", movementspeed);
        if (movementDirection.y > 0)
        {
            lookstate = Lookstate.Back;
        }
        if (movementDirection.y < 0)
        {
            lookstate = Lookstate.Front;
        }
        if (movementDirection.x < 0)
        {
            lookstate = Lookstate.Left;
        }
        if (movementDirection.x > 0)
        {
            lookstate = Lookstate.Right;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
        if(item != null)
        {
            inventory.AddItem(item);
        }
    }
}