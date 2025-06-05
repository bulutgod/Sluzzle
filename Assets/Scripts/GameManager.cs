using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int gridWidth = 4;
    public int gridHeight = 4;

    public GameObject tilePrefab;
    public float cellSpacing = 1.15f;
    public Vector2 startOffset = new Vector2(-1.71f, 1.95f);
    void Start()
    {
        CreateInitialGrid();
    }

    void Update()
    {
        
    }
    void CreateInitialGrid()
    {
        for(int y = 0; y < gridHeight; y++)
        {
            for (int x =0; x <gridWidth; x++)
                
            {
                Vector2 spawnPosition = new Vector2(startOffset.x + (x * cellSpacing), startOffset.y - (y * cellSpacing));
                if (tilePrefab != null)
                {
                    GameObject newTile = Instantiate(tilePrefab, spawnPosition, Quaternion.identity);
                    newTile.transform.SetParent(transform);
                    newTile.name = $"Tile_{x}_{y}";
                }
            }            
        }
    }
}
