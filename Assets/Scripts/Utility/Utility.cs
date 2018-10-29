using UnityEngine;
using UnityEngine.SceneManagement;

public static class Utility
{
    public static void LoadNextLevel()
    {
        Debug.ClearDeveloperConsole();

        int scene = SceneManager.GetActiveScene().buildIndex;

        Lives.Instance.IncreamentLife();

        GameManager.Instance.ResetGame();

        if (scene < (int)(Scenes.Level3))
            SceneManager.LoadScene(++scene);

        GameManager.Instance.NextLevelPanel.gameObject.SetActive(false);
    }

    public static int GetSignedUnity()
    {
        float number = Random.Range(-1, 1);

        return number >= 0 ? -1 : 1;
    }
}