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

        highlightMap_sown.RefreshAllTiles();
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
            else if (animator.GetBool("WateringCan") == true)
            {
                Water();
            }
            else if (Seeds == true && Isactive == true)
            {
                sow();
                Debug.Log("HIT");
            }
        }
        if (lookstate == Lookstate.Left && Isactive == true)
        {
            Isactive = false;
            animator.SetTrigger("Left");
            if (animator.GetBool("Hoe") == true)
            {
                Till();
            }
            else if (animator.GetBool("WateringCan") == true)
            {
                Water();
            }
            else if (Seeds == true && Isactive == true)
            {
                sow();
            }
        }
        if (lookstate == Lookstate.Right && Isactive == true)
        {
            Isactive = false;
            animator.SetTrigger("Right");
            if (animator.GetBool("Hoe") == true)
            {
                Till();
            }
            else if (animator.GetBool("WateringCan") == true)
            {
                Water();
            }
            else if (Seeds == true && Isactive == true)
            {
                sow();
            }
        }
        if (lookstate == Lookstate.Front && Isactive == true)
        {
            Isactive = false;
            animator.SetTrigger("Front");
            if (animator.GetBool("Hoe") == true)
            {
                Till();
            }
            else if (animator.GetBool("WateringCan") == true)
            {
                Water();
            }
            else if (Seeds == true && Isactive == true)
            {
                sow();
            }
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

    public Tile highlightTile_tilled;
    public Tilemap highlightMap_tilled;

    private Vector3Int previous;

    void Till()
    {
        Vector3Int currentCell = highlightMap_tilled.WorldToCell(transform.position);
        
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
            highlightMap_tilled.SetTile(currentCell, highlightTile_tilled);

            // erase previous
            //highlightMap.SetTile(previous, null);

            // save the new position for next frame
            previous = currentCell;
        }

    }
    // same function for watering
    public Tile highlightTile_watered;
    public Tilemap highlightMap_watered;

    private Vector3Int previous2;

    void Water()
    {
        Vector3Int currentCell = highlightMap_watered.WorldToCell(transform.position);

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
        if (currentCell != previous2)
        {
            // set the new tile
            highlightMap_watered.SetTile(currentCell, highlightTile_watered);

            // erase previous
            //highlightMap.SetTile(previous, null);

            // save the new position for next frame
            previous2 = currentCell;
        }

    }

    public Tile highlightTile_sown;
    public Tilemap highlightMap_sown;

    private Vector3Int previous3;

    void sow()
    {
        Vector3Int currentCell = highlightMap_sown.WorldToCell(transform.position);

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
        if (currentCell != previous3)
        {
            // set the new tile
            highlightMap_sown.SetTile(currentCell, highlightTile_sown);

            // erase previous
            //highlightMap.SetTile(previous, null);

            // save the new position for next frame
            previous3 = currentCell;
        }

    }
    // tijdelijke inventory
    public bool Seeds { get; set; } = false;

    void TempInventory()
    {
      //  animator.SetBool("Hoe", false);
        if (Input.GetKey(KeyCode.Alpha1) && animator.GetBool("WateringCan") != true)
        {
            animator.SetBool("WateringCan", true);
        }
        else if (Input.GetKey(KeyCode.Alpha1) && animator.GetBool("WateringCan") != false)
        {
            animator.SetBool("WateringCan", false);
        }
        if (Input.GetKey(KeyCode.Alpha2) && animator.GetBool("Hoe") != true)
        {
            animator.SetBool("Hoe", true);
            
        }
        else if (Input.GetKey(KeyCode.Alpha2) && animator.GetBool("Hoe") != false)
        {
            animator.SetBool("Hoe", false);
        }
        if (Input.GetKey(KeyCode.E) && Seeds == false)
        {
            Seeds = true;
            sow();
            //add the seeds function
        }
        else if (Input.GetKey(KeyCode.E) && Seeds == true)
        {
            Seeds = false;
        }
        
    }
}
