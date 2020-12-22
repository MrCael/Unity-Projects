using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject basicBullet;
    public GameObject heavyBullet;
    public GameObject teleportBullet;
    public GameObject timeBullet;
    private SpawnManager spawnManagerScript;
    private TeleportManager teleportManagerScript;
    private bool canMove = true;
    private bool noWall = true;
    private float tileLength = 1.11f;

    // Start is called before the first frame update
    void Start()
    {
        spawnManagerScript = GameObject.Find("Game Manager").GetComponent<SpawnManager>();
        teleportManagerScript = GameObject.Find("Teleport Manager").GetComponent<TeleportManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && canMove && checkForObstruction(new Vector3(transform.position.x, transform.position.y + tileLength, 0)) && transform.position.y + tileLength <= 4.01f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + tileLength, 0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && canMove && checkForObstruction(new Vector3(transform.position.x, transform.position.y - tileLength, 0)) && transform.position.y - tileLength >= -4.01f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - tileLength, 0);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && canMove && checkForObstruction(new Vector3(transform.position.x - tileLength, transform.position.y, 0)) && transform.position.x - tileLength >= -3.87f)
        {
            transform.position = new Vector3(transform.position.x - tileLength, transform.position.y, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && canMove && checkForObstruction(new Vector3(transform.position.x + tileLength, transform.position.y, 0)) && transform.position.x + tileLength <= 3.87f)
        {
            transform.position = new Vector3(transform.position.x + tileLength, transform.position.y, 0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instantiate(basicBullet, transform.position, transform.rotation);
            StartCoroutine(DelayMove(0.2f));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Instantiate(heavyBullet, transform.position, transform.rotation);
            StartCoroutine(DelayMove(0.2f));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Instantiate(teleportBullet, transform.position, transform.rotation);
            StartCoroutine(DelayMove(0.2f));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Instantiate(timeBullet, transform.position, transform.rotation);
            StartCoroutine(DelayMove(0.2f));
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 90);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 180);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 270);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        }

        if (teleportManagerScript.teleport)
        {
            transform.position = teleportManagerScript.pos;
            teleportManagerScript.teleport = false;
        }
    }

    public IEnumerator DelayMove(float time)
    {
        canMove = false;
        yield return new WaitForSeconds(time);
        canMove = true;
    }

    public bool checkForObstruction(Vector3 nextPos)
    {
        for (int i = 0; i < spawnManagerScript.occupied.Count; i++)
        {
            if (spawnManagerScript.occupied[i] != nextPos)
            {
                noWall = true;
            } else if (spawnManagerScript.occupied[i] == nextPos)
            {
                noWall = false;
                break;
            }
        }

        return noWall;
    }
}
