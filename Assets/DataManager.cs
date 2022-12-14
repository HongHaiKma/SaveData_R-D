using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-99)]
public class DataManager : Singleton<DataManager>
{
    public Obvious.Soap.IntVariable m_Gold;

    // public override void Awake()
    // {
    //     base.Awake();
    //     m_GoldSoap.OnValueChanged += OnGoldChanged;
    // }

    private void OnEnable()
    {
        m_Gold.Value = ES3.Load("Gold", m_Gold._initialValue);

        // Debug.Log("m_Gold: " + m_GoldSoap.Value.ToString());
        // Debug.Log("Gold ES: " + ES3.Load("Gold", m_GoldSoap._initialValue));

        m_Gold.OnValueChanged += OnGoldChanged;
    }

    private void OnDisable()
    {
        m_Gold.OnValueChanged -= OnGoldChanged;
    }

    private void OnDestroy()
    {
        // m_GoldSoap.OnValueChanged -= OnGoldChanged;
    }

    private void OnGoldChanged(int _value)
    {
        Debug.Log("SAVEEEEEEEEE: " + _value);
        ES3.Save("Gold", m_Gold.Value);
    }

    [Sirenix.OdinInspector.Button]
    public void ResetSOData()
    {
        m_Gold.Value = m_Gold._initialValue;
    }
}
