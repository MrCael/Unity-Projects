﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, new Vector3(-4, -4, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
