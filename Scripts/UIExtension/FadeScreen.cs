using System;
using System.Collections;
using System.Collections.Generic;
using Patterns;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviourSingletonAutoLoadUI<FadeScreen>
{
    public bool IsFadding { get; private set; }
    private Image image;
    private RectTransform rectTransform;
    private Color fadeColor = Color.black;

    private void Awake()
    {
        image = GetComponent<Image>();
        GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
    }

    public void FadeIn(float time=1, bool forceTo = false, bool force = false)
    {
        if (ResetFading(force))
        {
            StartCoroutine(forceTo ? ForceFader(0, 1, time) : Fader(1, time));
        }
    }

    public void FadeOut(float time=1, bool forceTo = false, bool force = false)
    {
        if (ResetFading(force))
        {
            StartCoroutine(forceTo ? ForceFader(1, 0, time) : Fader(0, time));
        }
    }

    public void FadeInOut(float time=1, float waitTime=0.5f, bool force = false)
    {
        if (ResetFading(force))
        {
            StartCoroutine(FaderInOut(time, waitTime));
        }
    }

    public void SetFadeColor(Color newFadeColor)
    {
        fadeColor = newFadeColor;
    }

    private bool ResetFading(bool force)
    {
        if (!force && IsFadding)
            return false;
        StopAllCoroutines();
        IsFadding = false;
        return true;
    }

    private IEnumerator Fader(float to, float time)
    {
        IsFadding = true;
        float delta = 0;
        float from = image.color.a;
        while (delta<1)
        {
            delta += Time.deltaTime * time;
            yield return null;
            image.color = GetColorWithAlpha(Mathf.Lerp(from, to, delta));
        }
        IsFadding = false;
    }

    private IEnumerator ForceFader(float from, float to, float time)
    {
        IsFadding = true;
        float delta = 0;
        
        while (delta<1)
        {
            delta += Time.deltaTime * time;
            yield return null;
            image.color = GetColorWithAlpha(Mathf.Lerp(from, to, delta));
        }
        IsFadding = false;
    }

    private IEnumerator FaderInOut(float simpleFadeTime, float waitTime)
    {
        IsFadding = true;
        yield return Fader(1, simpleFadeTime);
        IsFadding = true;
        yield return new WaitForSeconds(waitTime);
        yield return Fader(0, simpleFadeTime);
        IsFadding = false;
    }

    private Color GetColorWithAlpha(float alpha)
    {
        return new Color(fadeColor.r, fadeColor.b, fadeColor.g, alpha);
    }
}
