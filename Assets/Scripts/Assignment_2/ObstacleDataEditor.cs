using UnityEditor;
using UnityEngine;

/* This script isn't working as intended as 
 * it is not saving toggled grid points in the ScriptableObject (ObstacleData)
 * when the play button is pressed
 */
public class ObstacleDataEditor : EditorWindow
{
    public ObstacleData obstacleData;

    [MenuItem("Window/Obstacle Placement Tool")]
    public static void ShowWindow()
    {
        GetWindow(typeof(ObstacleDataEditor));
    }

    void OnGUI()
    {
        GUILayout.Label("Obstacle Placement Tool", EditorStyles.boldLabel);

        if (obstacleData == null)
        {
            EditorGUILayout.HelpBox("Assign an ObstacleData scriptable object.", MessageType.Info);
            return;
        }

        EditorGUI.BeginChangeCheck();

        for (int x = 0; x < 10; x++)
        {
            EditorGUILayout.BeginHorizontal();

            for (int y = 0; y < 10; y++)
            {
                bool isObstacle = obstacleData.obstacleGrid[x, y];
                bool newIsObstacle = EditorGUILayout.Toggle(isObstacle, GUILayout.Width(20));

                if (newIsObstacle != isObstacle)
                {
                    obstacleData.obstacleGrid[x, y] = newIsObstacle;
                }
            }

            EditorGUILayout.EndHorizontal();
        }

        if (EditorGUI.EndChangeCheck())
        {
            EditorUtility.SetDirty(obstacleData);
        }
    }
}
