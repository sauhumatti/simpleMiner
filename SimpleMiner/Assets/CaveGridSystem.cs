using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveGridSystem : MonoBehaviour

{
    public int gridWidth = 100;
    public int gridHeight = 100;
    public float cellSize = 1f;
    public GameObject tilePrefab;
    public Material emptyMaterial;
    public Material wallMaterial;

    private Tile[,] grid;
    private Vector2Int startPoint;

    [System.Serializable]
    public struct OreType
    {
        public string name;
        public float probability;
        public int depthThreshold;
        public Material material;
    }

    public OreType[] oreTypes;

    private void Start()
    {
        InitializeGrid();
        GenerateCave();
    }

    private void InitializeGrid()
    {
        grid = new Tile[gridWidth, gridHeight];
        startPoint = new Vector2Int(gridWidth / 2, gridHeight / 2);

        for (int x = 0; x < gridWidth; x++)
        {
            for (int z = 0; z < gridHeight; z++)
            {
                Vector3 worldPos = new Vector3(x * cellSize, 0, z * cellSize);
                GameObject tileObj = Instantiate(tilePrefab, worldPos, Quaternion.Euler(90, 0, 0), transform);
                tileObj.transform.localScale = new Vector3(cellSize, cellSize, 1);
                grid[x, z] = tileObj.GetComponent<Tile>();
                grid[x, z].Initialize(x, z, TileType.Wall);
            }
        }
    }

    private void GenerateCave()
    {
        // Simple cave generation using random walk
        Vector2Int currentPos = startPoint;
        int steps = gridWidth * gridHeight / 4; // Adjust for desired cave density

        for (int i = 0; i < steps; i++)
        {
            grid[currentPos.x, currentPos.y].SetType(TileType.Empty);

            // Random walk
            Vector2Int direction = GetRandomDirection();
            currentPos += direction;
            currentPos.x = Mathf.Clamp(currentPos.x, 0, gridWidth - 1);
            currentPos.y = Mathf.Clamp(currentPos.y, 0, gridHeight - 1);

            // Potentially place ore
            PlaceOre(currentPos);
        }

        // Ensure start point is empty
        grid[startPoint.x, startPoint.y].SetType(TileType.Empty);
    }

    private Vector2Int GetRandomDirection()
    {
        return new Vector2Int(Random.Range(-1, 2), Random.Range(-1, 2));
    }

    private void PlaceOre(Vector2Int position)
    {
        int depth = CalculateManhattanDistance(startPoint, position);
        float depthModifier = 1 + (depth / 1000f);

        foreach (OreType ore in oreTypes)
        {
            if (depth >= ore.depthThreshold && Random.value < ore.probability * depthModifier)
            {
                grid[position.x, position.y].SetType(TileType.Ore);
                grid[position.x, position.y].SetOreType(ore.name);
                grid[position.x, position.y].SetMaterial(ore.material);
                break;
            }
        }
    }

    private int CalculateManhattanDistance(Vector2Int a, Vector2Int b)
    {
        return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y);
    }

    public bool IsTileWalkable(int x, int z)
    {
        if (x < 0 || x >= gridWidth || z < 0 || z >= gridHeight)
            return false;
        return grid[x, z].GetType() != TileType.Wall;
    }

    public Tile GetTileAt(int x, int z)
    {
        if (x < 0 || x >= gridWidth || z < 0 || z >= gridHeight)
            return null;
        return grid[x, z];
    }

    public Vector3 GridToWorldPosition(int x, int z)
    {
        return new Vector3(x * cellSize, 0, z * cellSize);
    }
}
