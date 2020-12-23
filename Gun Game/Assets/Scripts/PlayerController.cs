using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameObject basicBullet;
    public GameObject heavyBullet;
    public GameObject teleportBullet;
    public TextMeshProUGUI actionsText;
    private SpawnManager spawnManagerScript;
    private TeleportManager teleportManagerScript;
    private bool canMove = true;
    private bool noWall = true;
    private int count;
    private float tileLength = 1.11f;

    // Start is called before the first frame update
    void Start()
    {
        spawnManagerScript = GameObject.Find("Game Manager").GetComponent<SpawnManager>();
        teleportManagerScript = GameObject.Find("Teleport Manager").GetComponent<TeleportManager>();
        actionsText = GameObject.Find("Actions Text").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        actionsText.text = "Actions: " + spawnManagerScript.actions.ToString();

        if (spawnManagerScript.actions > 0)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && canMove && checkForObstruction(new Vector3(transform.position.x, transform.position.y + tileLength, 0)) && transform.position.y + tileLength <= 4.01f)
            {
                spawnManagerScript.actions -= 1;
                checkIfLost();
                transform.position = new Vector3(transform.position.x, transform.position.y + tileLength, 0);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && canMove && checkForObstruction(new Vector3(transform.position.x, transform.position.y - tileLength, 0)) && transform.position.y - tileLength >= -4.01f)
            {
                spawnManagerScript.actions -= 1;
                checkIfLost();
                transform.position = new Vector3(transform.position.x, transform.position.y - tileLength, 0);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && canMove && checkForObstruction(new Vector3(transform.position.x - tileLength, transform.position.y, 0)) && transform.position.x - tileLength >= -4.01f)
            {
                spawnManagerScript.actions -= 1;
                checkIfLost();
                transform.position = new Vector3(transform.position.x - tileLength, transform.position.y, 0);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && canMove && checkForObstruction(new Vector3(transform.position.x + tileLength, transform.position.y, 0)) && transform.position.x + tileLength <= 3.87f)
            {
                spawnManagerScript.actions -= 1;
                checkIfLost();
                transform.position = new Vector3(transform.position.x + tileLength, transform.position.y, 0);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                spawnManagerScript.actions -= 1;
                for (int i = 0; i < spawnManagerScript.bullets.Count; i++)
                {
                    if (spawnManagerScript.bullets[i] != null)
                    {
                        Destroy(spawnManagerScript.bullets[i]);
                        break;
                    }
                }

                count = 0;
                for (int i = 0; i < spawnManagerScript.enemies.Count; i++)
                {
                    if (spawnManagerScript.enemies[i] == null)
                    {
                        count++;
                    }
                }

                if (spawnManagerScript.enemies.Count == count && transform.position == spawnManagerScript.endPos && spawnManagerScript.actions == 0)
                {
                    Debug.Log("You won!"); // Next level action
                }
                else
                {
                    checkIfLost();
                }
            }

            if (Input.GetKeyDown(KeyCode.A) && !(transform.eulerAngles == new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 90)))
            {
                spawnManagerScript.actions -= 1;
                checkIfLost();
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 90);
            }
            else if (Input.GetKeyDown(KeyCode.S) && !(transform.eulerAngles == new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 180)))
            {
                spawnManagerScript.actions -= 1;
                checkIfLost();
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 180);
            }
            else if (Input.GetKeyDown(KeyCode.D) && !(transform.eulerAngles == new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 270)))
            {
                spawnManagerScript.actions -= 1;
                checkIfLost();
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 270);
            }
            else if (Input.GetKeyDown(KeyCode.W) && !(transform.eulerAngles == new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0)))
            {
                spawnManagerScript.actions -= 1;
                checkIfLost();
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            }

            if (teleportManagerScript.teleport)
            {
                transform.position = teleportManagerScript.pos;
                teleportManagerScript.teleport = false;
            }
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

    public void checkIfLost()
    {
        if ((transform.position != spawnManagerScript.endPos && spawnManagerScript.actions < 1) || spawnManagerScript.actions < 1)
        {
            Debug.Log("You lost");
        }
    }
}
