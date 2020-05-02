using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class crops : Tile
{
    public GrowthLevel growthLevel { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        growthLevel = GrowthLevel.stage1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float Quality { get; set; }

    /// <summary>
    /// An array with all the Tiles that we have in our game
    /// </summary>
    [SerializeField]
    private Sprite[] tilledground;

    public enum GrowthLevel
    {
        stage1, //seedling
        stage2,
        stage3,
        stage4,
        stage5 //harvestable
    }

    /// <summary>
    /// Refreshes this tile when something changes
    /// </summary>
    /// <param name="position">The tiles position in the grid</param>
    /// <param name="tilemap">A reference to the tilemap that this tile belongs to.</param>
    
     public override void RefreshTile(Vector3Int position, ITilemap tilemap)
     {
        
        
     }
    Time Time = new Time();
    public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData)
    {
        /* if (growthLevel == GrowthLevel.stage1)
         {
             tileData.sprite = tilledground[0];
         }
         else if (growthLevel == GrowthLevel.stage2)
         {
             tileData.sprite = tilledground[1];
         }*/
        if (Input.GetKeyDown(KeyCode.E)) tileData.sprite = tilledground[0];
        else if (Input.GetKeyDown(KeyCode.R)) tileData.sprite = tilledground[1];
    }

#if UNITY_EDITOR
    [MenuItem("Assets/Create/Tiles/CropTile")]
    public static void CropTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save Croptile", "New Croptile", "asset", "Save Croptile", "Assets");
        if (path == "")
        {
            Debug.Log("geen path");
        }
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<crops>(), path);
    }
#endif
}
