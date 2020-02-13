using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


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
    bool Isactive = false;


    [SerializeField] private UI_Inventory uiInventory;
    private Inventory inventory;

    void start()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        Move();
        Animate();
        TempInventory();
        
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
            if (animator.GetBool("Hoe") == true)
            {
                Till();
            }
        }
        if (lookstate == Lookstate.Left && Isactive == true)
        {
            Isactive = false;
            Till();
            animator.SetTrigger("Left");
        }
        if (lookstate == Lookstate.Right && Isactive == true)
        {
            Isactive = false;
            Till();
            animator.SetTrigger("Right");
        }
        if (lookstate == Lookstate.Front && Isactive == true)
        {
            Isactive = false;
            Till();
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

    public Tile highlightTile;
    public Tilemap highlightMap;

    private Vector3Int previous;

    void Till()
    {
        Vector3Int currentCell = highlightMap.WorldToCell(transform.position);
        
       /* if (lookstate == Lookstate.Back)
        {
            currentCell.y += 1;
        } */
        if (lookstate == Lookstate.Front)
        {
            currentCell.y -= 2;
        }
        else if (lookstate == Lookstate.Left)
        {
            currentCell.x -= 1;
            currentCell.y -= 1;
        }
        else if (lookstate == Lookstate.Right)
        {
            currentCell.x += 1;
            currentCell.y += -1;
        }

        // if the position has changed
        if (currentCell != previous)
        {
            // set the new tile
            highlightMap.SetTile(currentCell, highlightTile);

            // erase previous
            //highlightMap.SetTile(previous, null);

            // save the new position for next frame
            previous = currentCell;
        }

    }
    // tijdelijke inventory
    
    void TempInventory()
    {
      //  animator.SetBool("Hoe", false);
        if (Input.GetKey(KeyCode.Alpha1))
        {
            animator.SetTrigger("WateringCan");
        }
        else if (Input.GetKey(KeyCode.Alpha2) && animator.GetBool("Hoe") != true)
        {
            animator.SetBool("Hoe", true);
            
        }
        else if (Input.GetKey(KeyCode.Alpha2) && animator.GetBool("Hoe") != false)
        {
            animator.SetBool("Hoe", false);
        }
        
    }
}
