using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GUIManager : Singleton<GUIManager>
{
    public void AddClickEvent(Button _bt, UnityAction _callback)
    {
        // _bt.OnPointerEnte
        _bt.onClick.AddListener(() =>
        {
            // SoundManager.Instance.PlayButtonClick();
            if (_callback != null)
            {
                _callback();
            }
        });
        // _bt.onCLick
    }

    void Test()
    {

    }
}
