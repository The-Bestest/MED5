using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Animator anim;
    int taskHash = Animator.StringToHash("taskOn");
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // anim.SetBool(taskHash, false);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger(taskHash);
            StartCoroutine(ResetAni(2));
        }
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
        StartCoroutine(ResetAni(2));
    }

    IEnumerator ResetAni(float aniTime)
    {
        yield return new WaitForSeconds(aniTime);
        anim.ResetTrigger(taskHash);
    }
}
