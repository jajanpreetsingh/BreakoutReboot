using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Residue : MonoBehaviour
{
    public GameObject[] Residues;
    // Use this for initialization
    void Start()
    {
        Residues[0].GetComponent<Rigidbody2D>().velocity = new Vector2(5, 8);
        Residues[1].GetComponent<Rigidbody2D>().velocity = new Vector2(5, 5);
        Residues[2].GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 8);
        Residues[3].GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 5);

        StartCoroutine(DestroyResidue());
    }

    private IEnumerator DestroyResidue()
    {
        yield return new WaitForSeconds(2);

        Destroy(gameObject);        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
