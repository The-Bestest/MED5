using Microsoft.VisualBasic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{

    public GameObject Balloon;
    public float freetime = 20;
    public float time4Cue = 3;
    public float time4Prep = 4; // Actual time is x2, it goes Ready when the phase begins, Set after the first time4Prep, Go after the second and then fades out
    public float time4Chill = 5;

    public float fadeOut = 1;

    public Text ReadySetGo;

    public BallonColourControl BCC;
    GameManager Manager;

    bool textBegin = true;

    bool started = false;
    public float time2NewStart = 5;
    float fullTime = 0;
    private int trials = 0;

    public void BeginText()
    {
        textBegin = !textBegin;
    }

    public void SetStart()
    {
        started = !started;
    }

    void Start()
    {
        //BCC = GameObject.Find("default").GetComponent<BallonColourControl>();
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //Balloon = GameObject.Find("balloon").GetComponent<GameObject>();
        // StartCoroutine(FreeCuePrep(freetime, time4Cue, time4Prep, fadeOut));
        ReadyTextBegin();
        fullTime = Manager.GetInputWindowSeconds() + Manager.GetInterTrialIntervalSeconds();
    }

    void Update()
    {
        if(started == true)
        {
            time2NewStart += Time.deltaTime;
            if(time2NewStart >= fullTime)
            {
                ReadyText();
                time2NewStart = 0;
            }
        }

    }

    public void ReadyTextBegin()
    {
        StartCoroutine(CoReadyTextBegin(time4Prep, freetime, time4Prep));
    }

    public void ReadyText()
    {
        StopCoroutine(CoChillText(time4Chill, fadeOut));
        StopCoroutine(CoPopText(time4Prep, fadeOut));
        StopCoroutine(CoReadyText(time4Prep, fadeOut));
        StartCoroutine(CoReadyText2(time4Chill, time4Cue, time4Prep, fadeOut));
    }

    public void PopText()
    {
        StopCoroutine(CoReadyText(time4Prep, fadeOut));
        StopCoroutine(CoReadyText2(time4Chill, time4Cue, time4Prep, fadeOut));
        StopCoroutine(CoChillText(time4Chill, fadeOut));
        StartCoroutine(CoPopText(time4Prep, fadeOut));
        trials++;

        Debug.Log("Trials: " + trials);
    }

    public void ChillText()
    {
        StopCoroutine(CoPopText(time4Prep, fadeOut));
        StopCoroutine(CoReadyText(time4Prep, fadeOut));
        StopCoroutine(CoReadyText2(time4Chill, time4Cue, time4Prep, fadeOut));
        StartCoroutine(CoChillText(time4Chill, fadeOut));
    }

    IEnumerator CoReadyTextBegin(float prep, float timer, float fadeTime)
    {
        ReadySetGo.color = new Color(1, 1, 1, 1);
        ReadySetGo.text = "Feel free to look around";
 
 
        yield return new WaitForSeconds(timer);
        ReadySetGo.color = new Color(1, 1, 1, 1);
        ReadySetGo.text = "Rest";

        yield return new WaitForSeconds(prep);
    }
    IEnumerator CoReadyText(float prep, float fadeTime)
    {
        //yield return new WaitForSeconds(timer);
        ReadySetGo.color = new Color(1, 1, 1, 1);
        ReadySetGo.text = "Ready!";
        BCC.ReadyColour();

        yield return new WaitForSeconds(time4Cue);

        ReadySetGo.color = new Color(1, 1, 0, 1);
        ReadySetGo.text = "Set!";
        BCC.SetColour();

        yield return new WaitForSeconds(time4Prep);
  
    }

    IEnumerator CoReadyText2(float chilltimer, float cuetimer, float preptimer, float fadeTime)
    {
        ReadySetGo.color = new Color(1, 1, 1, 1);
        ReadySetGo.text = "Rest";
        BCC.InterColour();
        yield return new WaitForSeconds(chilltimer);

        Balloon.SetActive(true);

        Balloon.SetActive(true);

        ReadySetGo.color = new Color(1, 0, 0, 1);
        ReadySetGo.text = "Ready!";
        BCC.ReadyColour();

        yield return new WaitForSeconds(cuetimer);

        ReadySetGo.color = new Color(1, 1, 0, 1);
        ReadySetGo.text = "Set!";
        BCC.SetColour();

        yield return new WaitForSeconds(preptimer);
    }

    IEnumerator CoPopText(float prep, float fadeTime)
    {
        ReadySetGo.color = new Color(0, 1, 0, 1);
        ReadySetGo.text = "Pop it!";
        BCC.TaskColour();
        yield return null;
    }

    IEnumerator CoChillText(float prep, float fadeTime)
    {
        ReadySetGo.color = new Color(1, 1, 1, 1);
        ReadySetGo.text = "Rest";
        BCC.InterColour();
        yield return new WaitForSeconds(prep);
    }
}