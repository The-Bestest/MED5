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
        }
        // AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

    }
}
