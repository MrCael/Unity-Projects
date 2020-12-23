using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject prefab;
    public List<Vector3> spaces = new List<Vector3>();
    private int x_start = -4, y_start = 4;
    private int columnLength = 6, rowLength = 6;
    private float x_space = 1.11f, y_space = 1.11f;
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < columnLength * rowLength; i++)
        {
            Instantiate(prefab, new Vector3(x_start + (x_space * (i % columnLength)), -y_start + (y_space * (i / columnLength))), Quaternion.identity);
            spaces.Add(new Vector3(x_start + (x_space * (i % columnLength)), -y_start + (y_space * (i / columnLength))));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
