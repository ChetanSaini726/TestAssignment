using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleData", menuName = "ScriptableObjects/ObstacleData", order = 1)]
public class ObstacleData : ScriptableObject
{ 
    public bool[,] obstacleGrid = new bool[10, 10]; // 10x10 grid to store obstacle presence
}
