using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Obvious.Soap
{
    [CustomEditor(typeof(BindComparisonToUnityEvent))]
    [CanEditMultipleObjects]
    public class BindComparisonToUnityEventDrawer : Editor
    {
        BindComparisonToUnityEvent _targetScript;
        SerializedProperty _boolVariable;
        SerializedProperty _boolComparer;
        SerializedProperty _intVariable;
        SerializedProperty _intComparer;
        SerializedProperty _floatVariable;
        SerializedProperty _floatComparer;
        SerializedProperty _stringVariable;
        SerializedProperty _stringComparer;
        SerializedProperty _unityEvent;

        void OnEnable()
        {
            _targetScript = (BindComparisonToUnityEvent)target;
            _boolVariable = serializedObject.FindProperty("_boolVariable");
            _boolComparer = serializedObject.FindProperty("_boolComparer");
            _intVariable = serializedObject.FindProperty("_intVariable");
            _intComparer = serializedObject.FindProperty("_intComparer");
            _floatVariable = serializedObject.FindProperty("_floatVariable");
            _floatComparer = serializedObject.FindProperty("_floatComparer");
            _stringVariable = serializedObject.FindProperty("_stringVariable");
            _stringComparer = serializedObject.FindProperty("_stringComparer");
            _unityEvent = serializedObject.FindProperty("_unityEvent");
        }

        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            Undo.RecordObject(_targetScript, "Modified Custom Inspector");
            _targetScript.Type = (CustomVariableType)EditorGUILayout.EnumPopup("Variable Type", _targetScript.Type);

            switch (_targetScript.Type)
            {
                case CustomVariableType.NONE:
                    break;
                case CustomVariableType.BOOL:
                    EditorGUILayout.PropertyField(_boolVariable, new GUIContent("Bool Variable"));
                    EditorGUILayout.PropertyField(_boolComparer, new GUIContent("Bool Comparer"));
                    EditorGUILayout.PropertyField(_unityEvent, new GUIContent("Event"));
                    break;
                case CustomVariableType.INT:
                    EditorGUILayout.PropertyField(_intVariable, new GUIContent("Int Variable"));
                    _targetScript.Comparison =
                        (BindComparisonToUnityEvent.Comparator)EditorGUILayout.EnumPopup("Operation",
                            _targetScript.Comparison);
                    EditorGUILayout.PropertyField(_intComparer, new GUIContent("Int Comparer"));
                    EditorGUILayout.PropertyField(_unityEvent, new GUIContent("Event"));
                    break;
                case CustomVariableType.FLOAT:
                    EditorGUILayout.PropertyField(_floatVariable, new GUIContent("Float Variable"));
                    _targetScript.Comparison =
                        (BindComparisonToUnityEvent.Comparator)EditorGUILayout.EnumPopup("Operation",
                            _targetScript.Comparison);
                    EditorGUILayout.PropertyField(_floatComparer, new GUIContent("Float Comparer"));
                    EditorGUILayout.PropertyField(_unityEvent, new GUIContent("Event"));
                    break;
                case CustomVariableType.STRING:
                    EditorGUILayout.PropertyField(_stringVariable, new GUIContent("String Variable"));
                    EditorGUILayout.PropertyField(_stringComparer, new GUIContent("String Comparer"));
                    EditorGUILayout.PropertyField(_unityEvent, new GUIContent("Event"));
                    break;
            }

            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
                if (!Application.isPlaying)
                    EditorSceneManager.MarkSceneDirty(UnityEngine.SceneManagement.SceneManager.GetActiveScene());
            }
        }
    }
}