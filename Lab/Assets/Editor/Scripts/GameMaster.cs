using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster {

    private static GameMaster instance = null;
    public static GameMaster Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameMaster();
            }
            return instance;
        }
        
    }

    public  GameObject MazeElement;
    public  GameObject GamePlane;
}
