using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GameObject Human;
    public GameObject Walls;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Human.SetActive(false);
            Walls.SetActive(true);
        } else if (Input.GetKeyDown(KeyCode.F))
        {
            Human.SetActive(true);
            Walls.SetActive(false);
        } else if (Input.GetKeyDown(KeyCode.N))
        {
            Human.SetActive(false);
            Walls.SetActive(false);
        }
    }
}
