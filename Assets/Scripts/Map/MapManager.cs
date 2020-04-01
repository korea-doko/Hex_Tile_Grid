using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{


    public MapView view;
    public MapModel model;

    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private List<Tile> neiborTileList;

    private void Awake()
    {
        neiborTileList = new List<Tile>();

        model.Init(width,height);
        view.Init(width,height,model);
    }

    private void Update()
    {
        if( Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast
                (
                    Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero
                );

            if (hit.collider != null)
            {
                Tile t = hit.collider.GetComponent<Tile>();


                ClearNeiborTile();
                GetNeigborTile(t);

                foreach (Tile tile in neiborTileList)
                    tile.ChangeColorTo(Color.red);

            }
        }
    }

    private void GetNeigborTile(Tile _center)
    {
        List<Tile> tileList = new List<Tile>();

        Tile leftTile = GetTile(_center.X - 1, _center.Y);
        Tile rightTile = GetTile(_center.X + 1, _center.Y);

        Tile leftDownTile = null;
        Tile rightDownTile = null;

        Tile leftTopTile = null;
        Tile rightTopTile = null;        
           
        if( _center.Y % 2 == 0)
        {
            // y index가 짝수 
            leftDownTile = GetTile(_center.X - 1, _center.Y - 1);
            rightDownTile = GetTile(_center.X , _center.Y - 1);
            leftTopTile = GetTile(_center.X - 1, _center.Y + 1);
            rightTopTile = GetTile(_center.X , _center.Y + 1);                   
        }
        else
        {
            // y index가 홀수
            leftDownTile = GetTile(_center.X, _center.Y - 1);
            rightDownTile = GetTile(_center.X+1 , _center.Y - 1);
            leftTopTile = GetTile(_center.X, _center.Y + 1);
            rightTopTile = GetTile(_center.X+1 , _center.Y + 1);
        }

        AddNeiborTile(_center);

        AddNeiborTile(leftTile);
        AddNeiborTile(rightTile);

        AddNeiborTile(leftTopTile);
        AddNeiborTile(leftDownTile);

        AddNeiborTile(rightTopTile);
        AddNeiborTile(rightDownTile);      
    }

    private void AddNeiborTile(Tile _tile)
    {
        if (_tile != null)
            neiborTileList.Add(_tile);
    }

    private Tile GetTile(int _x, int _y)
    {
        if (IsVaildIndex(_x, _y))
            return view.GetTile(_x, _y);

        return null;
    }

    private bool IsVaildIndex(int _x, int _y)
    {
        if (_x < 0 || _x >= width || _y < 0 || _y >= height)
            return false;

        return true;
    }
    
    private void ClearNeiborTile()
    {
        foreach (Tile tile in neiborTileList)
            tile.ChangeColorTo(Color.white);
         

        neiborTileList.Clear();
    }
 
}
