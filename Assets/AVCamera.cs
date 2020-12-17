using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AVCamera : MonoBehaviour
{

    public GameObject table;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(table.transform.position - new Vector3(2, -3, -2));
        transform.RotateAround(table.transform.position - new Vector3(2, -3, -2), Vector3.up, 35 * Time.deltaTime);
    }
}
