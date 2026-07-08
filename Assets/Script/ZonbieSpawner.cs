using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonbieSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Random.Range(0f, 360f);
        Vector3 pos = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad) * 20,0,Mathf.Sin(angle * Mathf.Deg2Rad) * 20);
    }
}
