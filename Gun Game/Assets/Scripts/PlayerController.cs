using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SpawnManager spawnManagerScript;
    public GameObject basicBullet;
    public GameObject heavyBullet;
    public GameObject teleportBullet;
    public GameObject timeBullet;
    private bool canMove = true;
    private bool noWall = true;
    private float tileLength = 1.11f;

    // Start is called before the first frame update
    void Start()
    {
        spawnManagerScript = GameObject.Find("Game Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && canMove && checkForWall(new Vector3(transform.position.x, transform.position.y + tileLength, 0)) && transform.position.y + tileLength <= 4.88f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + tileLength, 0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && canMove && checkForWall(new Vector3(transform.position.x, transform.position.y - tileLength, 0)) && transform.position.y - tileLength >= -4.88f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - tileLength, 0);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && canMove && checkForWall(new Vector3(transform.position.x - tileLength, transform.position.y, 0)) && transform.position.x - tileLength >= -4f)
        {
            transform.position = new Vector3(transform.position.x - tileLength, transform.position.y, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && canMove && checkForWall(new Vector3(transform.position.x + tileLength, transform.position.y, 0)) && transform.position.x + tileLength <= 4f)
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
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 90);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - 90);
        }
    }

    public IEnumerator DelayMove(float time)
    {
        canMove = false;
        yield return new WaitForSeconds(time);
        canMove = true;
    }

    public bool checkForWall(Vector3 nextPos)
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
