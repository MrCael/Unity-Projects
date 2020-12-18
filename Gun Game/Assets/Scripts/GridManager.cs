using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public float x_start, y_start;
    public int columnLength, rowLength;
    public float x_space, y_space;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < columnLength * rowLength; i++)
        {
            Instantiate(prefab, new Vector3(x_start + (x_space * (i % columnLength)), -y_start + (y_space * (i / columnLength))), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
