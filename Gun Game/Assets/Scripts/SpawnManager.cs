using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject wall;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemy, new Vector3(3.7f, 3.7f, 0), Quaternion.identity);
        Instantiate(player, new Vector3(-4, -4, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
