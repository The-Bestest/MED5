using UnityEngine;
using UnityEngine.UI;


public class KeyPressbutton : MonoBehaviour
{
    public Button Button;
    public Button Button2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Button.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Button2.onClick.Invoke();
        }
    }
}