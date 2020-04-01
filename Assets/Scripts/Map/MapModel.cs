using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapModel : MonoBehaviour
{
    public TileData[,] tileDataAry;

    [SerializeField] private int width;
    [SerializeField] private int height;

    public void Init(int _width,int _height)
    {
        this.width = _width;
        this.height = _height;
    
        tileDataAry = new TileData[_width, _height];

        for(int y = 0; y < _height; y++)
        {
            for(int x = 0; x< _width;x++)
            {
                tileDataAry[x, y] = new TileData(x, y);
            }
        }
    }
    public TileData GetTileData(int _x, int _y)
    {
        if (_x < 0 || _x >= width || _y < 0 || _y >= height)
            throw new IndexOutOfRangeException();

        return tileDataAry[_x, _y];
    }
}
