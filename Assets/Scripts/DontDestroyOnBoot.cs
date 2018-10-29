using UnityEngine;

public class DontDestroyOnBoot : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
       DontDestroyOnLoad(gameObject);
    }
}
