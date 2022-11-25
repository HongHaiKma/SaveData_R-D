using System.Globalization;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using MoreMountains.Tools;
using DG.Tweening;
using UnityEngine.Events;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ButtonBase : Button, IPointerDownHandler, IPointerUpHandler
{
    [Space]
    private Button btn_Owner;
    public Vector2 v2_OnClickDown;
    public Vector2 v2_OnClickUp;
    public float time;

    public UnityEvent m_OnButtonDown;
    public UnityEvent m_OnButtonUp;

    protected override void Awake()
    {
        base.Awake();
        btn_Owner = GetComponent<Button>();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        btn_Owner.transform.DOScale(v2_OnClickDown, time);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        btn_Owner.transform.DOScale(v2_OnClickUp, time);
    }
}

#if UNITY_EDITOR

[CustomEditor(typeof(ButtonBase))]
public class MyButtonInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}
#endif
