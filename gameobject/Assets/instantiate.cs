using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class instantiate : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;
    public Sprite Sprite1;
    public Sprite Sprite2;
    public Sprite Sprite3;
    public Sprite Sprite4;
    public Sprite Sprite5;
    public float growth_time = 10f;
    public Vector3 MovementDirection;
    int j = 0;
    int i = 0;
    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {

        // Instantiate at position (0, 0, 0) and zero rotation.
        //Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        //Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        //Instantiate(myPrefab, new Vector3(1, 0, 0), Quaternion.identity);


    }
    void Destroy()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(this.gameObject);
        }   
    }
    void Instantiating()
    {
        j++;
        i++;
        Instantiate(myPrefab, MovementDirection.normalized, Quaternion.identity);
    }

    void movement()
    {
        MovementDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void Update()
    {
        
        
        if (Input.GetKeyDown(KeyCode.E)) { Debug.Log("Hit"); Instantiating(); }
        growth_time = growth_time - Time.deltaTime;
        if (growth_time >= 9)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Sprite1;
        }
        else if (growth_time <= 9 && growth_time >= 5)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Sprite2;
        }
        else if (growth_time < 4)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Sprite5;
        }

        movement();

        //Destroy();
        
    }

/*    public override void RefreshTile(Vector3Int position, ITilemap tilemap)
    {
        tilemap.RefreshTile(position);
    }

    /// <summary>
    /// Changes the tiles sprite to the correct sprites based on the situation
    /// </summary>
    /// <param name="location">The location of this sprite</param>
    /// <param name="tilemap">A reference to the tilemap, that this tile belongs to</param>
    /// <param name="tileData">A reference to the actual object, that this tile belongs to</param>
    public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData)
    {
        tileData.gameObject = gameObject;


          
            
    }
        */

}
