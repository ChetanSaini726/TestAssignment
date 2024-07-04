using UnityEngine;
using System.Collections;

public class PlayerGridMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed of the player
    public ObstacleData obstacleData; // Reference to the obstacle data

    private Vector3 targetPosition; // Target position to move towards
    private bool isMoving = false; // Flag to track if the player is currently moving

    void Update()
    {
        if (!isMoving && Input.GetMouseButtonUp(0))
        {
            // Perform raycast to select tile
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f))
            {
                TileInfo tileInfo = hit.collider.GetComponent<TileInfo>();
                if (tileInfo != null)
                {
                    // Check if the selected tile is walkable (not obstructed)
                    if (!obstacleData.obstacleGrid[tileInfo.tileId.x, tileInfo.tileId.y])
                    {
                        // Start movement towards the selected tile
                        StartCoroutine(MoveToPosition(hit.point));
                    }
                    else
                    {
                        Debug.Log("Cannot move to an obstacle!");
                    }
                }
            }
        }
    }

    IEnumerator MoveToPosition(Vector3 position)
    {
        isMoving = true;
        targetPosition = new Vector3(Mathf.Round(position.x), transform.position.y, Mathf.Round(position.z));

        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPosition;
        isMoving = false;
    }
}
