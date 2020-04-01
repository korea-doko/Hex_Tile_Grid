using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * 참고https://www.redblobgames.com/grids/hexagons/       
 */

public class MapView : MonoBehaviour
{
   
    public Tile[,] tileAry;

    [SerializeField] private int width;
    [SerializeField] private int height;

    
    public void Init(int _width, int _height, MapModel model)
    {
    
        this.width = _width;
        this.height = _height;

        GameObject tilePrefab = Resources.Load("Prefabs/Tile") as GameObject;

        SpriteRenderer sp = tilePrefab.GetComponent<SpriteRenderer>();

        float size = sp.sprite.bounds.size.y * 0.5f;
        float tileWidth = size * Mathf.Sqrt(3.0f);
        float tileHeight = 2 * size;

        float offsetX = tileWidth * 0.1f;
        float offsetY = tileHeight* 0.1f;
        
        tileAry = new Tile[_width, _height];

       
     
        for(int y = 0; y < _height;y++)
        {
            for(int x= 0; x < _width; x++)
            {
                TileData td = model.GetTileData(x, y);

                Tile t = ((GameObject)Instantiate(tilePrefab)).GetComponent<Tile>();
                t.Init(td);
                t.transform.SetParent(this.transform);

                if( y % 2 == 0)
                {
                    t.transform.position = new Vector3
                    (
                        x * ( tileWidth + offsetX ),
                        ( y *  tileHeight * 0.75f ) + offsetY * y,
                        0.0f
                    );

                }
                else
                {
                    t.transform.position = new Vector3
                    (
                        x * (tileWidth + offsetX ) + (tileWidth + offsetX )* 0.5f ,
                        ( y * tileHeight * 0.75f ) + offsetY * y ,
                        0.0f
                    );
                }


                tileAry[x, y] = t;
            }
        }
    }

    public Tile GetTile(int _x, int _y)
    {
        if (_x < 0 || _x >= width || _y < 0 || _y >= height)
            throw new IndexOutOfRangeException();

        return tileAry[_x, _y];
    }

}
