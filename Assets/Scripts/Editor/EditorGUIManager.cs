using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Movement))]
public class EditorGUIManager : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Movement move = (Movement)target;
        #region Slider
        GUILayout.Label("-----Forces-----");

        move.movementForce = EditorGUILayout.Slider("SpeedForce", move.movementForce, 0.5f, 5f);
        move.jumpForce = EditorGUILayout.Slider("JumpForce", move.jumpForce, .2f, 10f);
        #endregion

        #region Buttons
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Something"))
        {

        }
        GUILayout.EndHorizontal();
        #endregion
    }
}
