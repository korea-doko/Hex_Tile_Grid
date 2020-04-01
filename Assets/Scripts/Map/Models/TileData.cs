using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileData 
{
    [SerializeField] private int x;
    [SerializeField] private int y;

    public int X { get => x; }
    public int Y { get => y; }

    public TileData(int _x, int _y)
    {
        this.x = _x;
        this.y = _y;
    }

}
