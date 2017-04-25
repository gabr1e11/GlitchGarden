using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour {

    public float FadeTime;

    Image m_image;

    bool m_fadeIn;
    bool m_fadeOut;
    float m_fadeTime;
    float m_fadeStartTime;

    void Awake () {
        m_image = GetComponent<Image>();
	}

    void Start()
    {
        FadeIn(FadeTime);
    }

    void Update()
    {
        UpdateFadeIn();
        UpdateFadeOut();
    }

    void UpdateFadeIn()
    {
        if (!m_fadeIn)
        {
            return;
        }
        float alpha = 1.0f - (Time.time - m_fadeStartTime) / m_fadeTime;
        m_image.color = new Color(m_image.color.r, m_image.color.g, m_image.color.b, alpha);

        if (alpha <= 0.0f)
        {
            m_fadeIn = false;
            gameObject.SetActive(false);
        }
    }

    void UpdateFadeOut()
    {
        if (!m_fadeOut)
        {
            return;
        }

        float alpha = (Time.time - m_fadeStartTime) / m_fadeTime;
        m_image.color = new Color(m_image.color.r, m_image.color.g, m_image.color.b, alpha);

        if (alpha >= 1.0f)
        {
            m_fadeOut = false;
        }
    }

    public void FadeIn(float seconds)
    {
        m_fadeIn = true;
        m_fadeOut = false;
        m_fadeTime = seconds;
        m_fadeStartTime = Time.time;
    }

    public void FadeOut(float seconds)
    {
        gameObject.SetActive(true);
        m_fadeIn = false;
        m_fadeOut = true;
        m_fadeTime = seconds;
        m_fadeStartTime = Time.time;
    }
    
}
