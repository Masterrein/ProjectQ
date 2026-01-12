using UnityEngine;

public class GroundTile : MonoBehaviour
{
        // This class can be expanded later for tile-specific behavior if needed
        public GroundGenerator groundGenerator;
        public MeshRenderer meshRenderer;
        public MeshFilter meshFilter;
        //public Material tileMaterial;
        //private Vector3 position;
        private Color color = Color.brown;
        //private float movementSpeed = 1f;
        //private bool farmable = false;
        private void Awake()
        {
        groundGenerator = FindAnyObjectByType<GroundGenerator>();
        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = CreateQuadMesh();
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = GetMaterial();
        }

        public Mesh CreateQuadMesh()
        {
        float tileSize = groundGenerator.tileSize;
        Mesh mesh = new Mesh();
            Vector3[] vertices = new Vector3[4]
            {
            new Vector3(0, 0, 0),
            new Vector3(0, 0, tileSize),
            new Vector3(tileSize, 0, 0),
            new Vector3(tileSize, 0, tileSize)
            };
            int[] triangles = new int[6]
            {
            0, 1, 2,
            2, 1, 3
            };
            Vector2[] uv = new Vector2[4]
            {
            new Vector2(0, 0),
            new Vector2(0, 1),
            new Vector2(1, 0),
            new Vector2(1, 1)
            };
            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.uv = uv;
            //mesh.RecalculateNormals();
            meshFilter.mesh = mesh;
            return mesh;
        }
        public Material GetMaterial()
        {
            Material material = groundGenerator.Material;
            return material;
        }
}

