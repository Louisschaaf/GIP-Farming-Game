using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class GlobalVariables
{

    private GlobalVariables() { }
    private static GlobalVariables instance = null;

    public static GlobalVariables GetInstance()
    {
        if (instance == null) instance = new GlobalVariables();
        return instance;
    }

    public Vector2 PLayer_Position { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
