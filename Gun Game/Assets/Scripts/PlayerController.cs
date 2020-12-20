using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 targetPos;
    private float tileLength = 1.1f;
    private float speed = 5f;
    private bool isMoving;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            isMoving = true;

            if (Input.GetKey(KeyCode.UpArrow))
            {
                targetPos = new Vector3(transform.position.x, transform.position.y + tileLength, 0);
                StartCoroutine(MovePlayer(targetPos, "up"));
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                targetPos = new Vector3(transform.position.x, transform.position.y - tileLength, 0);
                StartCoroutine(MovePlayer(targetPos, "down"));
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                targetPos = new Vector3(transform.position.x - tileLength, transform.position.y, 0);
                StartCoroutine(MovePlayer(targetPos, "left"));
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                targetPos = new Vector3(transform.position.x + tileLength, transform.position.y, 0);
                StartCoroutine(MovePlayer(targetPos, "right"));
            }

            Debug.Log("stopped");
            isMoving = false;
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    private IEnumerator MovePlayer(Vector3 tPos, string direc)
    {
        while (transform.position != tPos)
        {
            if (direc == "up")
            {
                Debug.Log(tPos);
                rb.velocity = new Vector3(0, speed, 0);
                if (transform.position.y > tPos.y)
                {
                    Debug.Log("test");
                    rb.velocity = new Vector3(0, 0, 0);
                    transform.position = tPos;
                }
            } else if (direc == "down")
            {
                rb.velocity = new Vector3(0, -speed, 0);
                if (transform.position.y < tPos.y)
                {
                    rb.velocity = new Vector3(0, 0, 0);
                    transform.position = tPos;
                }
            } else if (direc == "left")
            {
                rb.velocity = new Vector3(-speed, 0, 0);
                if (transform.position.x < tPos.x)
                {
                    rb.velocity = new Vector3(0, 0, 0);
                    transform.position = tPos;
                }
            } else if (direc == "right")
            {
                rb.velocity = new Vector3(speed, 0, 0);
                if (transform.position.x > tPos.x)
                {
                    rb.velocity = new Vector3(0, 0, 0);
                    transform.position = tPos;
                }
            }

            yield return null;
        }
    }
}
