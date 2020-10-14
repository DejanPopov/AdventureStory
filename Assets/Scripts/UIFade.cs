using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//UI
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{
    public static UIFade instance;

    //We are taking Alpha value of picture colour
    public Image fadeScreen;
    public float fadeSpeed;

    private bool shouldFadeToBlack;
    private bool shouldFadeFromBlack;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldFadeToBlack)
        {
            //Mathf.MoveTowards is gona push something in setted speed
            //DelaTime is amount of time it took to the last update to current update.
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g,
                fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, 
                fadeSpeed * Time.deltaTime));

            if (fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        }

        if (shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g,
                fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f,
                fadeSpeed * Time.deltaTime));

            if (fadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }
        }
    }

    public void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }

    public void FadeFromBlack()
    {
        shouldFadeToBlack = false;
        shouldFadeFromBlack = true;
    }
}
