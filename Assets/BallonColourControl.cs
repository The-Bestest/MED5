using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonColourControl : MonoBehaviour
{
    Renderer bRen;

    void Start()
    {
        bRen = this.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadyColour()
    {
        bRen.material.SetColor("_Color", Color.red);
    }

    public void SetColour()
    {
        bRen.material.SetColor("_Color", Color.yellow);
    }

    public void TaskColour()
    {
        bRen.material.SetColor("_Color", Color.green);
    }

    public void InterColour()
    {
        bRen.material.SetColor("_Color", Color.white);
    }
}
