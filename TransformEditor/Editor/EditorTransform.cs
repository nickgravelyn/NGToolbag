using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// Custom editor for the Transform component.
/// Adds buttons to reset local position, rotation and scale to their default values
/// </summary>
[CustomEditor(typeof(Transform))]
[CanEditMultipleObjects()]
public class EditorTransform : Editor {
	/// <summary>
	/// Size for reset buttons
	/// </summary>
	private const float BUTTON_WIDTH = 20f;

	public override void OnInspectorGUI() {
		// Should be called before editing the serialized property.
		serializedObject.Update();

		SerializedProperty posProp = serializedObject.FindProperty("m_LocalPosition");
		SerializedProperty rotProp = serializedObject.FindProperty("m_LocalRotation");
		SerializedProperty scaProp = serializedObject.FindProperty("m_LocalScale");

		// Position

		EditorGUILayout.BeginHorizontal();

		if (GUILayout.Button("P", EditorStyles.miniButton, GUILayout.Width(BUTTON_WIDTH))) {
			posProp.vector3Value = Vector3.zero;
		}

		EditorGUILayout.PropertyField(posProp, new GUIContent(""), false);

		EditorGUILayout.EndHorizontal();

		// Rotation
		EditorGUILayout.BeginHorizontal();

		if (GUILayout.Button("R", EditorStyles.miniButton, GUILayout.Width(BUTTON_WIDTH))) {
			rotProp.quaternionValue = Quaternion.identity;
		}

		rotProp.quaternionValue = Quaternion.Euler(EditorGUILayout.Vector3Field("", rotProp.quaternionValue.eulerAngles));

		EditorGUILayout.EndHorizontal();


		// Scale
		EditorGUILayout.BeginHorizontal();

		if (GUILayout.Button("S", EditorStyles.miniButton, GUILayout.Width(BUTTON_WIDTH))) {
			scaProp.vector3Value = Vector3.one;
		}

		EditorGUILayout.PropertyField(scaProp, new GUIContent(""), false);

		EditorGUILayout.EndHorizontal();

		// Apply any modifications
		serializedObject.ApplyModifiedProperties();
	}
}
