using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public float freetime = 20;
    public float time4Cue = 5;
    public float time4Prep = 2; // Actual time is x2, it goes Ready when the phase begins, Set after the first time4Prep, Go after the second and then fades out

    public float fadeOut = 1;

    public Text ReadySetGo;

    BallonColourControl BCC;
    GameManager Manager;

    bool textBegin = true;

    bool started = false;
    float time2NewStart = 0;
    float fullTime = 0;

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
        BCC = GameObject.Find("default").GetComponent<BallonColourControl>();
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
        StopCoroutine(CoPopText(time4Prep, fadeOut));
        StopCoroutine(CoReadyText(time4Prep, fadeOut));
        StartCoroutine(CoReadyText2(time4Prep, fadeOut));
    }

    public void PopText()
    {
        StopCoroutine(CoReadyText(time4Prep, fadeOut));
        StopCoroutine(CoReadyText2(time4Prep, fadeOut));
        StartCoroutine(CoPopText(time4Prep, fadeOut));
    }

    IEnumerator CoReadyTextBegin(float prep, float timer, float fadeTime)
    {
        ReadySetGo.color = new Color(1, 1, 1, 0);
        ReadySetGo.text = "Feel free to look around";
        while (ReadySetGo.color.a < 1)
        {
            ReadySetGo.color = new Color(ReadySetGo.color.r, ReadySetGo.color.g, ReadySetGo.color.b, ReadySetGo.color.a + (Time.deltaTime / fadeTime));
            yield return null;
        }
        yield return new WaitForSeconds(prep);
        while (ReadySetGo.color.a > 0)
        {
            ReadySetGo.color = new Color(ReadySetGo.color.r, ReadySetGo.color.g, ReadySetGo.color.b, ReadySetGo.color.a - (Time.deltaTime / fadeTime));
            yield return null;
        }
        yield return new WaitForSeconds(timer);
        ReadySetGo.color = new Color(1, 1, 1, 0);
        ReadySetGo.text = "Please focus on the balloon";
        while (ReadySetGo.color.a < 1)
        {
            ReadySetGo.color = new Color(ReadySetGo.color.r, ReadySetGo.color.g, ReadySetGo.color.b, ReadySetGo.color.a + (Time.deltaTime / fadeTime));
            yield return null;
        }
        yield return new WaitForSeconds(prep);
        while (ReadySetGo.color.a > 0)
        {
            ReadySetGo.color = new Color(ReadySetGo.color.r, ReadySetGo.color.g, ReadySetGo.color.b, ReadySetGo.color.a - (Time.deltaTime / fadeTime));
            yield return null;
        }
    }
    IEnumerator CoReadyText(float prep, float fadeTime)
    {
        //yield return new WaitForSeconds(timer);
        ReadySetGo.color = new Color(1, 1, 1, 0);
        ReadySetGo.text = "Ready!";
        BCC.ReadyColour();
        while (ReadySetGo.color.a < 1)
        {
            ReadySetGo.color = new Color(ReadySetGo.color.r, ReadySetGo.color.g, ReadySetGo.color.b, ReadySetGo.color.a + (Time.deltaTime / fadeTime));
            yield return null;
        }
        yield return new WaitForSeconds(prep);
        while (ReadySetGo.color.a > 0)
        {
            ReadySetGo.color = new Color(ReadySetGo.color.r, ReadySetGo.color.g, ReadySetGo.color.b, ReadySetGo.color.a - (Time.deltaTime / fadeTime));
            yield return null;
        }
        ReadySetGo.color = new Color(1, 1, 0, 0);
        ReadySetGo.text = "Set!";
        BCC.SetColour();
        while (ReadySetGo.color.a < 1)
        {
            ReadySetGo.color = new Color(ReadySetGo.color.r, ReadySetGo.color.g, ReadySetGo.color.b, ReadySetGo.color.a + (Time.deltaTime / fadeTime));
            yield return null;
        }
        yield return new WaitForSeconds(prep);
        while (ReadySetGo.color.a > 0)
        {
            ReadySetGo.color = new Color(ReadySetGo.color.r, ReadySetGo.color.g, ReadySetGo.color.b, ReadySetGo.color.a - (Time.deltaTime / fadeTime));
            yield return null;
        }
    }

    IEnumerator CoReadyText2(float prep, float fadeTime)
    {
        ReadySetGo.color = new Color(1, 0, 0, 0);
        ReadySetGo.text = "Ready!";
        BCC.ReadyColour();
        while (ReadySetGo.color.a < 1)
        {
            ReadySetGo.color = new Color(ReadySetGo.color.r, ReadySetGo.color.g, ReadySetGo.color.b, ReadySetGo.color.a + (Time.deltaTime / fadeTime));
            yield return null;
        }
        yield return new WaitForSeconds(prep);
        while (ReadySetGo.color.a > 0)
        {
            ReadySetGo.color = new Color(ReadySetGo.color.r, ReadySetGo.color.g, ReadySetGo.color.b, ReadySetGo.color.a - (Time.deltaTime / fadeTime));
            yield return null;
        }
        ReadySetGo.color = new Color(1, 1, 0, 0);
        ReadySetGo.text = "Set!";
        BCC.SetColour();
        while (ReadySetGo.color.a < 1)
        {
            ReadySetGo.color = new Color(ReadySetGo.color.r, ReadySetGo.color.g, ReadySetGo.color.b, ReadySetGo.color.a + (Time.deltaTime / fadeTime));
            yield return null;
        }
        yield return new WaitForSeconds(prep);
        while (ReadySetGo.color.a > 0)
        {
            ReadySetGo.color = new Color(ReadySetGo.color.r, ReadySetGo.color.g, ReadySetGo.color.b, ReadySetGo.color.a - (Time.deltaTime / fadeTime));
            yield return null;
        }
    }

    IEnumerator CoPopText(float prep, float fadeTime)
    {
        ReadySetGo.color = new Color(0, 1, 0, 1);
        ReadySetGo.text = "Try to pop the balloon!";
        BCC.TaskColour();
        while (ReadySetGo.color.a < 1)
        {
            ReadySetGo.color = new Color(ReadySetGo.color.r, ReadySetGo.color.g, ReadySetGo.color.b, ReadySetGo.color.a + (Time.deltaTime / fadeTime));
            yield return null;
        }
        yield return new WaitForSeconds(prep);
        while (ReadySetGo.color.a > 0)
        {
            ReadySetGo.color = new Color(ReadySetGo.color.r, ReadySetGo.color.g, ReadySetGo.color.b, ReadySetGo.color.a - (Time.deltaTime / (fadeTime)));
            yield return null;
        }
    }
}