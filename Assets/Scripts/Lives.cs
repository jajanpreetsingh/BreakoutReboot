using System.Collections.Generic;
using UnityEngine.UI;

public class Lives : Singleton<Lives>
{
    public List<Image> Live;

    int remainingLives;

    public bool AreChancesOver { get { return remainingLives <= 0; } }

    void Start()
    {
        remainingLives = Live.Count;
    }

    public void SetRemainingLives(int remLives)
    {
        if (remLives <= Live.Count && remLives >= 0)
        {
            for (int i = 0; i < Live.Count; i++)
                Live[i].gameObject.SetActive((i + 1) <= remLives);
        }
    }

    public void DecrementLife()
    {
        if (remainingLives <= 0)
            return;

        --remainingLives;
        SetRemainingLives(remainingLives);
    }

    public void IncreamentLife()
    {
        if (remainingLives >= Live.Count)
            return;

        ++remainingLives;
        SetRemainingLives(remainingLives);
    }
}