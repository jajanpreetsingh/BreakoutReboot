using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrail : MonoBehaviour
{
    public BallTrail Trail;

    Vector3 lastPos;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator UpdateTrailPositions()
    {
        while (true)
        {
            lastPos = gameObject.transform.position;

            yield return new WaitForSeconds(0.02f);

            Trail.gameObject.transform.position = lastPos;
        }
    }

    public void ResetTrail(Vector3 pos)
    {
        transform.position = pos;

        StopAllCoroutines();

        if (Trail != null)
            Trail.ResetTrail(pos);
    }

    public void StartTrail()
    {
        if (Trail != null)
            StartCoroutine(UpdateTrailPositions());

        if (Trail != null)
            Trail.StartTrail();
    }
}
