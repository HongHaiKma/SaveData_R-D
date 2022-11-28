using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainCanvas : MonoBehaviour
{
    public TextMeshProUGUI txt_Gold;
    public Obvious.Soap.IntVariable m_Gold;

    void OnEnable()
    {
        txt_Gold.text = m_Gold.Value.ToString();
    }

    public void ConsumeGold()
    {
        m_Gold.Value -= 10;
        ES3.Save("Gold", m_Gold.Value);

        txt_Gold.text = m_Gold.Value.ToString();
    }
}
