using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    private GameObject door;
    private Vector3 originalPos;
    void Start()
    {
        door = GameObject.FindGameObjectWithTag("Door");
        originalPos = transform.position;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.name == "Player")
        {
            transform.Translate(0, -0.01f, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = transform;
            Destroy(door);
        }
    }
}
