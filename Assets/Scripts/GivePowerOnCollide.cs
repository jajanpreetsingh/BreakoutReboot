using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivePowerOnCollide : MonoBehaviour
{
    AudioSource PowerUp;

    private void Start()
    {
        PowerUp = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (transform.position.y < PaddleControllor.Instance.gameObject.transform.position.y - 1)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != Tags.Paddle)
            return;

        PaddleControllor.Instance.GivePower();

        PowerUp.Play();
    }
}
