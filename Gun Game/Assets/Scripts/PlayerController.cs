using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject basicBullet;
    public GameObject heavyBullet;
    public GameObject teleportBullet;
    public GameObject timeBullet;
    private bool canMove = true;
    private float tileLength = 1.1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && canMove)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + tileLength, 0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && canMove)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - tileLength, 0);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && canMove)
        {
            transform.position = new Vector3(transform.position.x - tileLength, transform.position.y, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && canMove)
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
}
