using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    protected Button myButton;

    void Start()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(ClickHandler);
    }

    protected virtual void ClickHandler()
    {
        SoundManager.instance.PlayAudioClip("click");
    }
}
