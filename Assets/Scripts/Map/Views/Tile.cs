using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]
public class Tile : MonoBehaviour
{
    [SerializeField] private int x;
    [SerializeField] private int y;

    SpriteRenderer sr;


    public int X { get => x; }
    public int Y { get => y; }

    
    public void Init(TileData td)
    {
        this.x = td.X;
        this.y = td.Y;

        sr = this.GetComponent<SpriteRenderer>();
    }

    public void ChangeColorTo(Color _color)
    {
        sr.color = _color;
    }

}
