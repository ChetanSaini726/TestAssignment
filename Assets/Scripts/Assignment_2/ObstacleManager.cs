using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public ObstacleData obstacleData;
    public GameObject obstaclePrefab; // Red sphere prefab

    void Start()
    {
        GenerateObstacles();
    }

    void GenerateObstacles()
    {
        for (int x = 0; x < 10; x++)
        {

            for (int y = 0; y < 10; y++)
            {
                // Temporary solution for spawning obstacles
                /*if (x % 3 == 0 && y % 5 == 0)
                {
                    obstacleData.obstacleGrid[x, y] = true;
                }*/
                if (obstacleData.obstacleGrid[x, y])
                {
                    
                    // Calculate position of the obstacle
                    Vector3 position = new Vector3(x, 1f, y); // Adjust y value as needed

                    // Instantiate obstacle prefab (red sphere)
                    GameObject obstacle = Instantiate(obstaclePrefab, position, Quaternion.identity);
                    obstacle.transform.parent = transform; // Set parent to this GameObject
                }
            }
        }
    }
}
