using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    private float speed = 7f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
}
