using System.IO;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    [SerializeField] private int defaultWidth = 50;
    [SerializeField] private int defaultLength = 50;
    public float tileSize = 0.25f;
    public Material Material;
    private void Awake()
    {
        GenerateGround(defaultWidth, defaultLength);
    }

    private void GenerateGround(int width, int height) 
    { 
    int tilesPerRow = Mathf.RoundToInt((width / tileSize));
    int tilesPerColumn = Mathf.RoundToInt((height / tileSize));
        for (int x = 0; x < tilesPerRow; x++)
        {
            for (int z = 0; z < tilesPerColumn; z++)
            {
                GroundTile tile = new GameObject("GroundTile").AddComponent<GroundTile>();
                tile.transform.position = new Vector3(x * tileSize, 0, z * tileSize);
                tile.transform.parent = this.transform;
                
            }
        }

    }
}


