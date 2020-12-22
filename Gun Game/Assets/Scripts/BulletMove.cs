using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public GameObject player;
    public string bulletType;
    private float tileLength = 1.11f;
    private float speed = 7f;
    private SpawnManager spawnManagerScript;
    private TeleportManager teleportManagerScript;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        teleportManagerScript = GameObject.Find("Teleport Manager").GetComponent<TeleportManager>();
        spawnManagerScript = GameObject.Find("Game Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
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

        if (transform.position.y > 6f || transform.position.y < -6f || transform.position.x > 6f || transform.position.x < -6f)
        {
            Destroy(gameObject);
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
                    spawnManagerScript.occupied.RemoveAt(i);
                }
            }
            Destroy(other.gameObject);
            if (bulletType != "heavy")
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
