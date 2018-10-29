using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public BrickType Color;
    // Use this for initialization
    public GameObject[] DirtTiles;

    int maxHits = 2;

    int hits = 0;

    GameObject Residue;

    Vector3 pos;

    bool scoreincremented;

    void Start()
    {
        Residue = Resources.Load<GameObject>("Prefabs/Residue");
        pos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnDestroy()
    {
    }

    public void Hit()
    {
        Instantiate(Residue, pos, Quaternion.identity);

        GameManager.Instance.PlayWallBreakSound();

        if (!scoreincremented)
            GameManager.Instance.IncreamentScore();

        scoreincremented = true;

        ++hits;

        if (hits == maxHits - 1)
            new List<GameObject> { DirtTiles[1], DirtTiles[2] }.ForEach(x => Destroy(x.transform.Find("Mine").gameObject));

        if (hits >= maxHits)
            Destroy(gameObject);
    }

    int GetScoreByType()
    {
        switch (Color)
        {
            case BrickType.White:
                return 1;
            case BrickType.Blue:
                return 2;
            case BrickType.Green:
                return 2;
            case BrickType.Red:
                return 3;
        }
        return 1;
    }
}