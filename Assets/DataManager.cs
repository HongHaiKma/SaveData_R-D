using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-99)]
public class DataManager : Singleton<DataManager>
{
    public Obvious.Soap.IntVariable m_GoldSoap;

    // public override void Awake()
    // {
    //     base.Awake();
    //     m_GoldSoap.OnValueChanged += OnGoldChanged;
    // }

    private void OnEnable()
    {
        m_GoldSoap.Value = ES3.Load("Gold", m_GoldSoap._initialValue);

        m_GoldSoap.OnValueChanged += OnGoldChanged;
    }

    private void OnDisable()
    {
        m_GoldSoap.OnValueChanged -= OnGoldChanged;
    }

    private void OnDestroy()
    {
        m_GoldSoap.OnValueChanged -= OnGoldChanged;
    }

    private void OnGoldChanged(int _value)
    {
        Debug.Log("SAVEEEEEEEEE: " + _value);
        ES3.Save("Gold", m_GoldSoap.Value);
    }
}
