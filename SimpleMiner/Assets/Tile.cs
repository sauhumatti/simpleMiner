using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private int x;
    private int z;
    private TileType type;
    private string oreType;
    private MeshRenderer meshRenderer;

    public void Initialize(int xPos, int zPos, TileType tileType)
    {
        x = xPos;
        z = zPos;
        meshRenderer = GetComponent<MeshRenderer>();
        SetType(tileType);
    }

    public void SetType(TileType newType)
    {
        type = newType;
        UpdateVisuals();
    }

    public TileType GetType()
    {
        return type;
    }

    public void SetOreType(string newOreType)
    {
        oreType = newOreType;
    }

    public void SetMaterial(Material material)
    {
        meshRenderer.material = material;
    }

    private void UpdateVisuals()
    {
        CaveGridSystem gridSystem = transform.parent.GetComponent<CaveGridSystem>();
        switch (type)
        {
            case TileType.Empty:
                meshRenderer.material = gridSystem.emptyMaterial;
                break;
            case TileType.Wall:
                meshRenderer.material = gridSystem.wallMaterial;
                break;
            case TileType.Ore:
                // Ore material is set separately
                break;
        }
    }
}

public enum TileType
{
    Empty,
    Wall,
    Ore
}