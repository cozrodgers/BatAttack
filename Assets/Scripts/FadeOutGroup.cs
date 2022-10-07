using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutGroup : MonoBehaviour
{
    float fadeOutTime = 2f;
    CanvasGroup cg;
    bool shouldFadeOut;
    void Start()
    {
        cg = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        if (GameManager.Instance.IsPlaying == false)
        {
            cg.alpha += Time.deltaTime / fadeOutTime;

        }
    }

}
