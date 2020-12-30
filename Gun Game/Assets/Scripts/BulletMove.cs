using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public string bulletType;
    private float tileLength = 1.11f;
    private float speed = 7f;
    private bool destroyTime;
    private SpawnManager spawnManagerScript;
    private TeleportManager teleportManagerScript;
    private PauseMenu pauseMenuScript;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        teleportManagerScript = GameObject.Find("Teleport Manager").GetComponent<TeleportManager>();
        spawnManagerScript = GameObject.Find("Game Manager").GetComponent<SpawnManager>();
        pauseMenuScript = GameObject.Find("Pause Menu Canvas").GetComponent<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pauseMenuScript.gameIsPaused)
        {
            if ((int)transform.eulerAngles.z == 0)
            {
                rb.velocity = new Vector3(0, speed, 0);
            }
            if ((int)transform.eulerAngles.z == 180)
            {
                rb.velocity = new Vector3(0, -speed, 0);
            }
            if ((int)transform.eulerAngles.z == 270)
            {
                rb.velocity = new Vector3(speed, 0, 0);
            }
            if ((int)transform.eulerAngles.z == 90)
            {
                rb.velocity = new Vector3(-speed, 0, 0);
            }

            if (transform.position.y > 4f || transform.position.y < -8f || transform.position.x > 4f || transform.position.x < -7f)
            {
                Destroy(gameObject);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (bulletType == "teleport" && !other.CompareTag("bullet"))
        {
            if ((int)transform.eulerAngles.z == 0)
            {
                teleportManagerScript.pos = new Vector3(other.transform.position.x, other.transform.position.y - tileLength, 0);
            }
            if ((int)transform.eulerAngles.z == 180)
            {
                teleportManagerScript.pos = new Vector3(other.transform.position.x, other.transform.position.y + tileLength, 0);
            }
            if ((int)transform.eulerAngles.z == 90)
            {
                teleportManagerScript.pos = new Vector3(other.transform.position.x + tileLength, other.transform.position.y, 0);
            }
            if ((int)transform.eulerAngles.z == 270)
            {
                teleportManagerScript.pos = new Vector3(other.transform.position.x - tileLength, other.transform.position.y, 0);
            }
            teleportManagerScript.teleport = true;
        }

        if (other.CompareTag("enemy") || other.CompareTag("crate"))
        {
            for (int i = 0; i < spawnManagerScript.occupied.Count; i++)
            {
                if (other.transform.position == spawnManagerScript.occupied[i])
                {
                    if (bulletType == "time")
                    {
                        if (other.transform.position == spawnManagerScript.finalTarget)
                        {
                            destroyTime = true;
                            spawnManagerScript.occupied.RemoveAt(i);
                            Destroy(other.gameObject);
                        }
                    }
                    else
                    {
                        spawnManagerScript.occupied.RemoveAt(i);
                        Destroy(other.gameObject);
                    }
                }
            }

            if (bulletType != "heavy" && destroyTime)
            {
                Destroy(gameObject);
            }
        }
        else if (other.CompareTag("wall"))
        {
            Destroy(gameObject);
        }
    }
}
