using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject wall;
    public List<Vector3> occupied = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, new Vector3(-4, -4, 0), Quaternion.identity);
        Instantiate(enemy, new Vector3(3.77f, 3.77f, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(-4, 3.77f, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(-2.89f, 3.77f, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(-1.78f, 3.77f, 0), Quaternion.identity);
        occupied.Add(new Vector3(3.77f, 3.77f, 0));
        occupied.Add(new Vector3(-4, 3.77f, 0));
        occupied.Add(new Vector3(-2.89f, 3.77f, 0));
        occupied.Add(new Vector3(-1.78f, 3.77f, 0));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
