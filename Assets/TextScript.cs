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

    void Start()
    {
        StartCoroutine(FreeCuePrep(freetime, time4Cue, time4Prep, fadeOut));
        ReadySetGo.color = new Color(0, 0, 0, 0);
    }

    public void Tasker()
    {
        StartCoroutine(CuePrep(0, time4Cue, time4Prep, fadeOut));
    }

    IEnumerator FreeCuePrep(float lookAround, float cue, float prep, float fadeTime)
    {
        ReadySetGo.color = new Color(0, 0, 0, 0);
        ReadySetGo.text = "Have a look a round.";
        while (ReadySetGo.color.a < 1)
        {
            ReadySetGo.color = new Color(ReadySetGo.color.r, ReadySetGo.color.g, ReadySetGo.color.b, ReadySetGo.color.a + (Time.deltaTime / fadeTime));
            yield return null;
        }
        yield return new WaitForSeconds(lookAround);
        while (ReadySetGo.color.a > 0)
        {
            ReadySetGo.color = new Color(ReadySetGo.color.r, ReadySetGo.color.g, ReadySetGo.color.b, ReadySetGo.color.a - (Time.deltaTime / fadeTime));
            yield return null;
        }
        ReadySetGo.text = "Please look at the baloon.";
        while (ReadySetGo.color.a < 1)
        {
            ReadySetGo.color = new Color(ReadySetGo.color.r, ReadySetGo.color.g, ReadySetGo.color.b, ReadySetGo.color.a + (Time.deltaTime / fadeTime));
            yield return null;
        }
        yield return new WaitForSeconds(cue);
        while (ReadySetGo.color.a > 0)
        {
            ReadySetGo.color = new Color(ReadySetGo.color.r, ReadySetGo.color.g, ReadySetGo.color.b, ReadySetGo.color.a - (Time.deltaTime / fadeTime));
            yield return null;
        }
        ReadySetGo.color = new Color(1, 0, 0, 0);
        ReadySetGo.text = "Ready!";
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
        ReadySetGo.color = new Color(0, 1, 0, 1);
        ReadySetGo.text = "Try to pop the baloon!";
        while (ReadySetGo.color.a < 1)
        {
            ReadySetGo.color = new Color(ReadySetGo.color.r, ReadySetGo.color.g, ReadySetGo.color.b, ReadySetGo.color.a + (Time.deltaTime / fadeTime));
            yield return null;
        }

        while (ReadySetGo.color.a > 0)
        {
            ReadySetGo.color = new Color(ReadySetGo.color.r, ReadySetGo.color.g, ReadySetGo.color.b, ReadySetGo.color.a - (Time.deltaTime / (fadeTime * 2)));
            yield return null;
        }

    }

IEnumerator CuePrep(float lookAround, float cue, float prep, float fadeTime)
    {
        ReadySetGo.color = new Color(0, 0, 0, 0);
        while (ReadySetGo.color.a > 0)
        {
            ReadySetGo.color = new Color(ReadySetGo.color.r, ReadySetGo.color.g, ReadySetGo.color.b, ReadySetGo.color.a - (Time.deltaTime / fadeTime));
            yield return null;
        }
        ReadySetGo.text = "Please look at the baloon.";
        while (ReadySetGo.color.a < 1)
        {
            ReadySetGo.color = new Color(ReadySetGo.color.r, ReadySetGo.color.g, ReadySetGo.color.b, ReadySetGo.color.a + (Time.deltaTime / fadeTime));
            yield return null;
        }
        yield return new WaitForSeconds(cue);
        while (ReadySetGo.color.a > 0)
        {
            ReadySetGo.color = new Color(ReadySetGo.color.r, ReadySetGo.color.g, ReadySetGo.color.b, ReadySetGo.color.a - (Time.deltaTime / fadeTime));
            yield return null;
        }
        ReadySetGo.color = new Color(1, 0, 0, 0);
        ReadySetGo.text = "Ready!";
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
        ReadySetGo.color = new Color(0, 1, 0, 1);
        ReadySetGo.text = "Try to pop the baloon!";
        while (ReadySetGo.color.a < 1)
        {
            ReadySetGo.color = new Color(ReadySetGo.color.r, ReadySetGo.color.g, ReadySetGo.color.b, ReadySetGo.color.a + (Time.deltaTime / fadeTime));
            yield return null;
        }

        while (ReadySetGo.color.a > 0)
        {
            ReadySetGo.color = new Color(ReadySetGo.color.r, ReadySetGo.color.g, ReadySetGo.color.b, ReadySetGo.color.a - (Time.deltaTime / (fadeTime*2)));
            yield return null;
        }

    }
}