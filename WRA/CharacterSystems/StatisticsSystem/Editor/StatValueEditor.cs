#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;
using WRA.CharacterSystems.StatisticsSystem.Statistics;

namespace WRA.CharacterSystems.StatisticsSystem.Editor
{
    [CustomPropertyDrawer(typeof(StatValue))]
    public class StatisticsHolderEditor : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty statValue = property.FindPropertyRelative("statValue");

            float labelWidth = EditorGUIUtility.labelWidth;
            float halfPositionWidth = position.width / 2;
            EditorGUIUtility.labelWidth = halfPositionWidth;
            EditorGUI.PropertyField(new Rect(position.x, position.y, position.width, position.height), statValue, new GUIContent(property.name));
            EditorGUIUtility.labelWidth = EditorGUIUtility.labelWidth / 2;
        }
    }
}
#endif