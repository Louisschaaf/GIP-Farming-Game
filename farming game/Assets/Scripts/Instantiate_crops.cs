using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Instantiate_crops : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;
    public Sprite Sprite1;
    public Sprite Sprite2;
    public Sprite Sprite3;
    public Sprite Sprite4;
    public Sprite Sprite5;
    public float growth_time = 10f;
    public Vector2 MovementDirection;
    public Vector2 Npos = GlobalVariables.GetInstance().PLayer_Position;
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
        Instantiate(myPrefab,Npos, Quaternion.identity);
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

        Npos = GlobalVariables.GetInstance().PLayer_Position;
        
        //Destroy();
    }
}
