using UnityEditor;
using UnityEngine;

namespace Obvious.Soap
{
    [CustomEditor(typeof(PlayModeResetter))]
    public class PlayModeResetterDrawer : Editor
    {
        private SerializedObject _serializedTargetObject;

        public override void OnInspectorGUI()
        {
            DrawWarningLabel();
            SoapInspectorUtils.DrawLine();
            EditorGUILayout.Space();
            DrawPathInstructions();
            
            if (_serializedTargetObject == null)
                _serializedTargetObject = new SerializedObject(target);
            _serializedTargetObject.DrawInspectorExcept("m_Script");
            
            SoapInspectorUtils.DrawLine();
            DrawButton();
        }

        private void DrawWarningLabel()
        {
            var color = GUI.contentColor;
            GUI.contentColor = Color.red;
            var guiStyle = EditorStyles.whiteLargeLabel;
            guiStyle.wordWrap = true;
            EditorGUILayout.LabelField("Has to be located in a Resources folder and named PlayModeResetter", guiStyle);
            GUI.contentColor = color;
        }

        private void DrawPathInstructions()
        {
            var guiStyle = EditorStyles.miniLabel;
            guiStyle.wordWrap = true;
            EditorGUILayout.LabelField("Change the path to where are located your scriptable variables & lists", guiStyle);
        }

        private void DrawButton()
        {
            if (GUILayout.Button("Get all scriptable variables at path", GUILayout.MinHeight(25)))
            {
                var variableResetter = (PlayModeResetter)target;
                variableResetter.GetAllVariablesAtPath();
            }
        }
    }
}