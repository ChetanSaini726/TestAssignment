using UnityEngine;

public class GridGenerator : MonoBehaviour
{

    public GameObject cubePrefab;
    public int gridSize = 10;

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    void Generate()
    {
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                Vector3 pos = new Vector3(x, 0, y);

                GameObject cube = Instantiate(cubePrefab, pos, Quaternion.identity);
                cube.transform.parent = this.transform;
                cube.GetComponent<TileInfo>().tileId = new Vector2Int((int)pos.x, (int)pos.z);
            }
        }

    }
}
