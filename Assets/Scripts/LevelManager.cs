using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType : ushort
{
    Empty = 0,
    Player1Head = 1,
    Player1Trail = 2,
    Player2Head = 3,
    Player2Trail = 4
}

public class LevelManager : MonoBehaviour
{
    private TileType[,] level = new TileType[10, 10];
    public TileType[,] Level
    {
        get => level;
        set
        {
            level = value;
        }
    }
    public void updateLevelTrail(int x, int y, TileType tileType)
    {
        level[x,y] = tileType;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            string s = "";
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    s += level[i, j] + " ";
                }
                s += "\n";
            }
            Debug.Log(s);
        }
    }
}
