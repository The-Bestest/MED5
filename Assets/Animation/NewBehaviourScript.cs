using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject Ball;
    Animator anim;
    int taskHash = Animator.StringToHash("taskOn");
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Ball = GameObject.Find("balloon");
    }

    // Update is called once per frame
    void Update()
    {
        // anim.SetBool(taskHash, false);
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger(taskHash);
            StartCoroutine(ResetAni(2));
        }*/
        // AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

    }

    public void StartAniHand()
    {
        //Start animation
        anim.SetTrigger(taskHash);
        //Animation goes squeez and then back to normal position
        StartCoroutine(ResetAni(2));
    }

    public void StartAniBalloon()
    {
        //Start animation
        anim.SetTrigger(taskHash);
        //Animation goes squeez and then back to normal position
        StartCoroutine(ResetAni(GameObject.Find("Main Camera").GetComponent<TextScript>().time2NewStart));
    }

    IEnumerator ResetAni(float aniTime)
    {
        yield return new WaitForSeconds(0.5f);
        Ball.SetActive(false);
        Debug.Log(aniTime);
        yield return new WaitForSeconds(aniTime - 0.5f);
        Ball.SetActive(true);
        anim.ResetTrigger(taskHash);
    }
}
