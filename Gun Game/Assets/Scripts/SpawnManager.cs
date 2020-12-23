using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject wall;
    public GameObject crate;
    public GameObject end;
    public GameObject basic;
    public GameObject heavy;
    public GameObject teleport;
    public GameObject time;
    public GameObject timeBullet;
    public Vector3 endPos;
    public Vector3 finalTarget;
    public Quaternion endRot;
    public List<Vector3> occupied = new List<Vector3>();
    public List<GameObject> enemies = new List<GameObject>();
    public List<string> bullets = new List<string>();
    public GridManager gridManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        gridManagerScript = GameObject.Find("Grid Manager").GetComponent<GridManager>();

        Instantiate(player, gridManagerScript.spaces[0], Quaternion.identity);
        Instantiate(end, gridManagerScript.spaces[6], Quaternion.identity);
        endPos = gridManagerScript.spaces[6];
        Instantiate(enemy, gridManagerScript.spaces[30], Quaternion.identity);
        occupied.Add(gridManagerScript.spaces[30]);
        Instantiate(timeBullet, gridManagerScript.spaces[6], Quaternion.Euler(0, 0, 0));
        finalTarget = gridManagerScript.spaces[30];
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("enemy"))
        {
            enemies.Add(item);
        }
        bullets.Add("Basic");
        bullets.Add("Basic");
        bullets.Add("Time");
        for (int i = 0; i < bullets.Count; i++)
        {
            Vector3 xPos = new Vector3(0, -5.7f, 0); // Change this to space bullets equally distant from the left of the grid.

            if (bullets[i] == basic.name)
            {
                Instantiate(basic, xPos, Quaternion.identity);
            }
            if (bullets[i] == heavy.name)
            {
                Instantiate(heavy, xPos, Quaternion.identity);
            }
            if (bullets[i] == teleport.name)
            {
                Instantiate(teleport, xPos, Quaternion.identity);
            }
            if (bullets[i] == time.name)
            {
                Instantiate(time, xPos, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
