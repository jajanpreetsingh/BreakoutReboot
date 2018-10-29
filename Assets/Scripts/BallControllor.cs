using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControllor : Singleton<BallControllor>
{
    Rigidbody2D rigidBody;

    Vector2 initialPos;

    BallTrail Trail;

    const float initialForce = 7;

    //Vector2 initialVel;

    float maxMag;

    public BallState State { set; get; }

    void Start()
    {
        State = BallState.Reset;

        initialPos = transform.position;

        rigidBody = GetComponent<Rigidbody2D>();

        Trail = GetComponent<BallTrail>();
    }

    public void StartGame()
    {
        rigidBody.AddForce(new Vector2(Utility.GetSignedUnity() * initialForce, initialForce * .85f), ForceMode2D.Impulse);

        maxMag = rigidBody.velocity.magnitude;

        //initialVel = rigidBody.velocity;

        State = BallState.Playing;

        Trail.StartTrail();
    }

    void Update()
    {
        if (GameManager.Instance.State != GameState.Playing)
            return;

        if (rigidBody.velocity.x == 0)
            rigidBody.velocity += new Vector2(3, 0);

        if (rigidBody.velocity.y == 0)
            rigidBody.velocity += new Vector2(0, 3);

        if (rigidBody.velocity.magnitude > maxMag)
        {
            rigidBody.velocity = rigidBody.velocity.normalized * maxMag;
        }
    }

    public void SetColor(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
    }

    public void ResetGame()
    {
        gameObject.transform.position = initialPos;

        rigidBody.velocity = new Vector2(0, 0);

        State = BallState.Reset;

        Trail.ResetTrail(transform.position);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        DestroyBricks(other.gameObject);
    }

    public void DestroyBricks(GameObject other)
    {
        Brick brick = other.gameObject.GetComponent<Brick>();

        if (brick == null)
            return;

        brick.Hit();
    }
}