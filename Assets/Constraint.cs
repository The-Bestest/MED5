using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Constraint : MonoBehaviour
{
    public Camera Cam;
    public bool constrain;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (constrain == true)
        {
            InputTracking.Recenter();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            constrain = false;
        }
    }
}
