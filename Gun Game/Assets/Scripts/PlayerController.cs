using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 targetPos;
    public float tileLength = 1.1f;
    public float speed = 5f;
    public bool isMoving;
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
            float xmov = Input.GetAxisRaw("Horizontal");
            float ymov = Input.GetAxisRaw("Vertical");

            if (xmov < 0 && ymov < 0)
            {
                targetPos = new Vector3(transform.position.x - tileLength, transform.position.y - tileLength, 0);
            }

            if (xmov < 0 && ymov > 0)
            {
                targetPos = new Vector3(transform.position.x - tileLength, transform.position.y + tileLength, 0);
            }

            if (xmov > 0 && ymov < 0)
            {
                targetPos = new Vector3(transform.position.x + tileLength, transform.position.y - tileLength, 0);
            }

            if (xmov > 0 && ymov > 0)
            {
                targetPos = new Vector3(transform.position.x + tileLength, transform.position.y + tileLength, 0);
            }

            while (transform.position != targetPos)
            {
                rb.velocity = new Vector3(xmov * speed, ymov * speed, 0);
            }
        }

        isMoving = false;
    }
}
