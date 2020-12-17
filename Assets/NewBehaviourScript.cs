using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject Balloon;
    public GameObject Wall;
    public GameObject Human;


    private Animator handAnim;
    private Animator WallAnim;
    private Animator balloonAnim;
    private int taskHash;

    void Start()
    {
        taskHash = Animator.StringToHash("taskOn");
        handAnim = Human.GetComponent<Animator>();
        WallAnim = Wall.GetComponent<Animator>();
        balloonAnim = Balloon.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.Animate();
        }
    }

    public void Animate()
    {
        handAnim.Play("sittingSqueeze", -1, 0);
        WallAnim.Play("WallCrush", -1, 0);
        balloonAnim.Play("BalloonSqueez", -1, 0);
        StartCoroutine(ResetAni(GameObject.Find("Camera").GetComponent<TextScript>().time2NewStart));
    }

    IEnumerator ResetAni(float aniTime)
    {
        yield return new WaitForSeconds(0.5f); //Time before balloon disaappears
        Balloon.SetActive(false); // Ball "animation" start
        //yield return new WaitForSeconds(1f);   // Time before Balloon comes back
        //Balloon.SetActive(true); // Ball "animation" end
    }
}
