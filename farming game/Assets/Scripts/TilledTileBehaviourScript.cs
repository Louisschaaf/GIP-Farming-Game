using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;

public class TilledTileBehaviourScript : Tile
{
    /// <summary>
    /// An array with all the Tiles that we have in our game
    /// </summary>
    [SerializeField]
    private Sprite[] tilledground;

    //A preview of the tile
    [SerializeField]
    private Sprite preview;

    /// <summary>
    /// Refreshes this tile when something changes
    /// </summary>
    /// <param name="position">The tiles position in the grid</param>
    /// <param name="tilemap">A reference to the tilemap that this tile belongs to.</param>
    public override void RefreshTile(Vector3Int position, ITilemap tilemap)
    {
        for (int y = -1; y <= 1; y++) //Runs through all the tile's neighbours 
        {
            for (int x = -1; x <= 1; x++)
            {
                //We store the position of the neighbour 
                Vector3Int nPos = new Vector3Int(position.x + x, position.y + y, position.z);

                if (IsTilled(tilemap, nPos)) //If the neighbour is tilled
                {
                    tilemap.RefreshTile(nPos); //Them we make sure to refresh the neighbour aswell
                }
            }
        }
    }

    /// <summary>
    /// Changes the tiles sprite to the correct sprites based on the situation
    /// </summary>
    /// <param name="location">The location of this sprite</param>
    /// <param name="tilemap">A reference to the tilemap, that this tile belongs to</param>
    /// <param name="tileData">A reference to the actual object, that this tile belongs to</param>
    public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData)
    {
        string composition = string.Empty;//Makes an empty string as compostion, we need this so that we change the sprite

        for (int x = -1; x <= 1; x++)//Runs through all neighbours 
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x != 0 || y != 0) //Makes sure that we aren't checking our self
                {
                    //If the value is a tilledtile
                    if (IsTilled(tilemap, new Vector3Int(location.x + x, location.y + y, location.z)))
                    {
                        composition += 'T';
                    }
                    else
                    {
                        composition += 'G';
                    }


                }
            }
        }



        //Changes the sprite based on what we see.
        if (composition[1] == 'G' && composition[3] == 'G' && composition[4] == 'G' && composition[6] == 'G')
        {
            tileData.sprite = tilledground[0];
        }
        else if (composition[1] == 'T' && composition[3] == 'T' && composition[4] == 'G' && composition[6] == 'G')
        {
            tileData.sprite = tilledground[3];
        }
        else if (composition[1] == 'T' && composition[3] == 'G' && composition[4] == 'T' && composition[6] == 'G')
        {
            tileData.sprite = tilledground[9];
        }
        else if (composition[1] == 'G' && composition[3] == 'G' && composition[4] == 'T' && composition[6] == 'T')
        {
            tileData.sprite = tilledground[7];
        }
        else if (composition[1] == 'G' && composition[3] == 'T' && composition[4] == 'G' && composition[6] == 'T')
        {
            tileData.sprite = tilledground[1];
        }
        else if (composition[1] == 'T' && composition[3] == 'G' && composition[4] == 'G' && composition[6] == 'T')
        {
            tileData.sprite = tilledground[14];
        }
        else if (composition[1] == 'G' && composition[3] == 'G' && composition[4] == 'G' && composition[6] == 'T')
        {
            tileData.sprite = tilledground[13];
        }
        else if (composition[1] == 'G' && composition[3] == 'G' && composition[4] == 'T' && composition[6] == 'G')
        {
            tileData.sprite = tilledground[12];
        }
        else if (composition[1] == 'G' && composition[3] == 'T' && composition[4] == 'G' && composition[6] == 'G')
        {
            tileData.sprite = tilledground[10];
        }
        else if (composition[1] == 'T' && composition[3] == 'G' && composition[4] == 'G' && composition[6] == 'G')
        {
            tileData.sprite = tilledground[15];
        }
        else if (composition[1] == 'G' && composition[3] == 'T' && composition[4] == 'T' && composition[6] == 'T')
        {
            tileData.sprite = tilledground[4];
        }
        else if (composition[1] == 'T' && composition[3] == 'G' && composition[4] == 'T' && composition[6] == 'T')
        {
            tileData.sprite = tilledground[8];
        }
        else if (composition[1] == 'T' && composition[3] == 'T' && composition[4] == 'G' && composition[6] == 'T')
        {
            tileData.sprite = tilledground[2];
        }
        else if (composition[1] == 'T' && composition[3] == 'T' && composition[4] == 'T' && composition[6] == 'G')
        {
            tileData.sprite = tilledground[6];
        }
        else if (composition[1] == 'T' && composition[3] == 'T' && composition[4] == 'T' && composition[6] == 'T')
        {
            tileData.sprite = tilledground[5];
        }
        else if (composition[1] == 'G' && composition[3] == 'T' && composition[4] == 'T' && composition[6] == 'G')
        {
            tileData.sprite = tilledground[11];
        }

    }
        

    public bool IsTilled(ITilemap tilemap, Vector3Int position)
    {
        return tilemap.GetTile(position) == this;
    }


#if UNITY_EDITOR
    [MenuItem("Assets/Create/Tiles/TilledTile")]
    public static void tilledTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save tilledtile", "New tilledtile", "asset", "Save tilledtile", "Assets");
        if (path == "")
        {
            Debug.Log("geen path");
        }
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<TilledTileBehaviourScript>(), path);
    }

#endif
}

