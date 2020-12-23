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
    public List<GameObject> bullets = new List<GameObject>();
    public List<string> bulletNames = new List<string>();
    public GridManager gridManagerScript;
    public int actions;

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
        bulletNames.Add("Time");
        for (int i = 0; i < bulletNames.Count; i++)
        {
            Vector3 xPos = new Vector3((i * 1.11f) - 4f, -5.7f, 0);
            if (bulletNames[i] == basic.name)
            {
                Instantiate(basic, xPos, Quaternion.identity);
            }
            if (bulletNames[i] == heavy.name)
            {
                Instantiate(heavy, xPos, Quaternion.identity);
            }
            if (bulletNames[i] == teleport.name)
            {
                Instantiate(teleport, xPos, Quaternion.identity);
            }
            if (bulletNames[i] == time.name)
            {
                Instantiate(time, xPos, Quaternion.identity);
            }
        }
        foreach(GameObject bullet in GameObject.FindGameObjectsWithTag("bulletui"))
        {
            bullets.Add(bullet);
        }
        actions = 2;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
