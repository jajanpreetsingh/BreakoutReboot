using System;
using System.Collections;
using UnityEngine;

public class PaddleControllor : Singleton<PaddleControllor>
{
    const float paddleSpeed = 12;
    //BallControllor ball;

    Vector3 initialPos;

    internal void GivePower()
    {
        shootLaser = true;
    }

    bool shootLaser;

    public GameObject Sword;
    public Transform LeftLaserPos;
    public Transform RightLaserPos;

    void Start()
    {
        //ball = FindObjectOfType<BallControllor>();

        initialPos = transform.position;

        StartCoroutine(StartShooting());
    }

    private IEnumerator StartShooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            if (shootLaser)
            {
                Instantiate(Sword, LeftLaserPos.position, Quaternion.Euler(0, 0, 45));
                Instantiate(Sword, RightLaserPos.position, Quaternion.Euler(0, 0, 45));
            }
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) && gameObject.transform.position.x <= 5.6)
        {
            gameObject.transform.position += new Vector3(paddleSpeed * Time.deltaTime, 0, 0);

            if (ShouldBallFollow())
                    BallControllor.Instance.transform.position += new Vector3(paddleSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && gameObject.transform.position.x >= -5.6)
        {
            gameObject.transform.position -= new Vector3(paddleSpeed * Time.deltaTime, 0, 0);

            if (ShouldBallFollow())
                BallControllor.Instance.transform.position -= new Vector3(paddleSpeed * Time.deltaTime, 0, 0);
        }

        if (InputControllor.GetPressedKey() == KeyCode.Return)
        {
            shootLaser = !shootLaser;
        }
    }

    bool ShouldBallFollow()
    {
        return BallControllor.Instance.State == BallState.Reset;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == Tags.Ball)
        {
            //SetColor(ball.GetComponent<SpriteRenderer>().color);
        }
    }

    public void ResetGame()
    {
        gameObject.transform.position = initialPos;

        shootLaser = false;
    }

    //public void SetColor(Color color)
    //{
    //    GetComponent<SpriteRenderer>().color = color;
    //}
}