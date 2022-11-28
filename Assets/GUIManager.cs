using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using TMPro;


public class GUIManager : Singleton<GUIManager>
{
    void Start()
    {
        Addressables.LoadSceneAsync("GamePlay", LoadSceneMode.Single).Completed += LoadPlaySceneCompleted;
    }

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

    void LoadPlaySceneCompleted(AsyncOperationHandle<SceneInstance> _scene)
    {
        if (_scene.Status == AsyncOperationStatus.Succeeded)
        {
            // DataManager.Instance.Awake();
        }
    }


    void Test()
    {

    }
}
