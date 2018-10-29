using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public Text ScoreText;
    public int Score { set; get; }

    public RectTransform GameOverPanel;
    public RectTransform NextLevelPanel;

    //BallControllor ball;
    //PaddleControllor paddle;

    int noOfBricks;

    public GameState State { set; get; }

    void Start()
    {
        gameObject.AddComponent<DontDestroyOnBoot>();

        Score = 0;

        State = GameState.Stopped;
        InitializeBallAndPaddle();

        SetScoreTest();

        DebugSomething();
    }

    public void InitializeBallAndPaddle()
    {
        //BallControllor[] balls = FindObjectsOfType<BallControllor>();
        //PaddleControllor[] paddles = FindObjectsOfType<PaddleControllor>();

        //if (balls != null)
        //{
        //    ball = balls[0];

        //    for (int i = 1; i < balls.Length; i++)
        //        Destroy(balls[i].gameObject);
        //}

        //if (paddles != null)
        //{
        //    paddle = paddles[0];

        //    for (int i = 1; i < paddles.Length; i++)
        //        Destroy(paddles[i].gameObject);
        //}

        //ball = FindObjectOfType<BallControllor>();
        //paddle = FindObjectOfType<PaddleControllor>();

        BallControllor.Initialize();
        PaddleControllor.Initialize();

        SetState(GameState.Stopped);
    }

    public void GameOver()
    {
        ResetGame();

        SetState(GameState.Over);
    }

    public void Restart()
    {
        FindObjectsOfType<DontDestroyOnBoot>().ToList().ForEach(x => Destroy(x.gameObject));

        SceneManager.LoadScene(Scenes.Level1.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (State != GameState.Playing
            && State != GameState.Over
            && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }

        if (IsLevelComplete())
        {
            NextLevelPanel.gameObject.SetActive(true);

            ResetGame();
        }
    }

    public void LoadNextLevel()
    {
        Utility.LoadNextLevel();
    }

    public bool IsLevelComplete()
    {
        Brick[] bricks = FindObjectsOfType<Brick>();//("Brick");

        if (bricks != null && bricks.Length == 1)
            Debug.Log(bricks[0].gameObject.name + "   " + bricks[0].transform.position);

        return bricks == null || bricks.Length <= 0;
    }

    void SetScoreTest()
    {
        ScoreText.text = string.Format("{0}", Score);
    }

    public void IncreamentScore(int inc = 1)
    {
        Score += inc;

        SetScoreTest();

        --noOfBricks;

        if (IsLevelComplete())
        {
            NextLevelPanel.gameObject.SetActive(true);

            ResetGame();
        }
    }

    void StartGame()
    {
        BallControllor.Instance.StartGame();

        SetState(GameState.Playing);

        Lives.Instance.DecrementLife();
    }

    public void ResetGame()
    {
        BallControllor.Instance.ResetGame();
        PaddleControllor.Instance.ResetGame();

        SetState(GameState.Stopped);
    }

    void UpdateUI()
    {
        GameOverPanel.gameObject.SetActive(State == GameState.Over);
    }

    void OnApplicationPause(bool pause)
    {
    }

    public void SetState(GameState state)
    {
        State = state;
        UpdateUI();
    }

    public void InitializeBrickCount(int noOfBricks)
    {
        Initialize();
        InitializeBallAndPaddle();
        this.noOfBricks = noOfBricks;


        NextLevelPanel.gameObject.SetActive(false);
    }

    public void PlayWallBreakSound()
    {
        GetComponent<AudioSource>().Play();
    }

    void DebugSomething()
    {
    }
}