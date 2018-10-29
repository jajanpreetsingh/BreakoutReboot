using UnityEngine;

public class ChangeColorOnContact : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == Tags.Ball)
        {
            collision.gameObject.GetComponent<BallControllor>().SetColor(GetComponent<SpriteRenderer>().color);
        }
    }
}