using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    Rigidbody2D rBody;
    float speed = 10;
    // Use this for initialization
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        rBody.velocity = Vector2.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += Vector3.up * speed * Time.deltaTime;//  new Vector3(, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DestroyBricks(other.gameObject);
        
        if (other.gameObject.tag == "Boundary" || other.gameObject.tag == "Brick")
            Destroy(gameObject);
    }

    public void DestroyBricks(GameObject other)
    {
        Brick brick = other.gameObject.GetComponent<Brick>();

        if (brick == null)
            return;

        brick.Hit();
    }
}
