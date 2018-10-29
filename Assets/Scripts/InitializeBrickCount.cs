using UnityEngine;

public class InitializeBrickCount : MonoBehaviour
{
    private void Start()
    {
        Brick[] bricks = FindObjectsOfType<Brick>();
        int noOfBricks = bricks == null ? 0 : bricks.Length;

        GameManager.Instance.InitializeBrickCount(noOfBricks);
    }
}