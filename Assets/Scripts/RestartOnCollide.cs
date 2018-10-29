using UnityEngine;

public class RestartOnCollide : MonoBehaviour
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
            if (!Lives.Instance.AreChancesOver)
                GameManager.Instance.ResetGame();
            else
            {
                GameManager.Instance.GameOver();
            }
        }
    }
}