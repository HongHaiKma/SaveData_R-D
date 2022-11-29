using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainCanvas : MonoBehaviour
{
    public TextMeshProUGUI txt_Gold;
    public TextMeshProUGUI txt_Gold2;
    public Obvious.Soap.IntVariable m_Gold;

    void OnEnable()
    {
        // m_Gold2.Value = DataManager.Instance.m_GoldSoap.Value;
        // txt_Gold.text = m_Gold.Value.ToString();
        // Debug.Log("Gold OnEnable: " + m_Gold.Value.ToString());
        // Debug.Log("Gold ES OnEnable: " + ES3.Load("Gold", m_Gold._initialValue));
        // txt_Gold2.text = DataManager.Instance.m_GoldSoap.Value.ToString();
        m_Gold = DataManager.Instance.m_Gold;
        txt_Gold.text = m_Gold.Value.ToString();

        // m_Gold.OnValueChanged += OnChangedValue;
    }

    private void OnDisable()
    {
        // m_Gold.OnValueChanged -= OnChangedValue;
    }

    [Sirenix.OdinInspector.Button]
    public void ConsumeGold()
    {
        m_Gold.Value -= 10;
        // m_Gold.Save();
        // ES3.Save("Gold", m_Gold.Value);

        // Debug.Log("Gold ConsumeGold: " + m_Gold.Value);
        // Debug.Log("Gold ES ConsumeGold: " + ES3.Load("Gold", m_Gold._initialValue));

        txt_Gold.text = m_Gold.Value.ToString();
        // txt_Gold.text = DataManager.Instance.m_GoldSoap.Value.ToString();
    }

    void OnChangedValue(int _value)
    {
        Debug.Log("GGGGGGGGGGGGG");
    }

    // [Sirenix.OdinInspector.Button]
    // public void Test()
    // {
    //     txt_Gold.text = DataManager.Instance.m_Gold.Value.ToString();
    // }
}
