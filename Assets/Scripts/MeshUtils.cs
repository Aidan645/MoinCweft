using UnityEngine;

public static class MeshUtils
{
    private static Mesh s_UnitQuad;
    private static Mesh s_UnitCube;

    public static Mesh UnitQuad
    {
        get
        {
            if (s_UnitQuad == null)
            {
                s_UnitQuad = new Mesh();
                s_UnitQuad.vertices = new Vector3[] { new Vector3(0f, 0f, 0f), new Vector3(1f, 0f, 1f), new Vector3(1f, 0f, 0f), new Vector3(0f, 1f, 0f) };
                s_UnitQuad.triangles = new int[] { 0, 1, 2, 0, 2, 3 };
                s_UnitQuad.RecalculateBounds();
                s_UnitQuad.RecalculateNormals();
            }
            return s_UnitQuad;
        }
    }

    public static Mesh UnitCube
    {
        get
        {
            if (s_UnitCube == null)
            {
                s_UnitCube = new Mesh();
                s_UnitCube.vertices = new Vector3[]
                {
                    // Bottom face
                    new Vector3(-0.5f, -0.5f, -0.5f), //lo
                    new Vector3(0.5f,-0.5f, -0.5f), // lb
                    new Vector3(-0.5f, -0.5f, 0.5f), // ro
                    new Vector3(0.5f, -0.5f, 0.5f), // rb

                    // Top face
                    new Vector3(-0.5f, 0.5f, -0.5f),
                    new Vector3(-0.5f, 0.5f, 0.5f),
                    new Vector3(0.5f, 0.5f, -0.5f),
                    new Vector3(0.5f, 0.5f, 0.5f),

                    // Left face
                    new Vector3(0.5f, -0.5f, 0.5f),
                    new Vector3(0.5f, 0.5f, 0.5f),
                    new Vector3(-0.5f, -0.5f, 0.5f),
                    new Vector3(-0.5f, 0.5f, 0.5f),

                    // Right face
                    new Vector3(-0.5f, -0.5f, -0.5f),
                    new Vector3(-0.5f, 0.5f, -0.5f),
                    new Vector3(0.5f, -0.5f, -0.5f),
                    new Vector3(0.5f, 0.5f, -0.5f),

                    // Front face
                    new Vector3(-0.5f, -0.5f, 0.5f),
                    new Vector3(-0.5f, 0.5f, 0.5f),
                    new Vector3(-0.5f, -0.5f, -0.5f),
                    new Vector3(-0.5f, 0.5f, -0.5f),

                    // Back face
                    new Vector3(0.5f, -0.5f, -0.5f),
                    new Vector3(0.5f, 0.5f, -0.5f),
                    new Vector3(0.5f, -0.5f, 0.5f),
                    new Vector3(0.5f, 0.5f, 0.5f),
                };
                float third = 1/3f;
                s_UnitCube.uv = new Vector2[]
                {
                    // bottom face
                    new Vector2(0.25f,0f),
                    new Vector2(0.25f,third),
                    new Vector2(0.50f,0),
                    new Vector2(0.50f,third),
                    // top face 
                    new Vector2(0.25f ,2*third),
                    new Vector2(0.25f,1),
                    new Vector2(0.50f,2*third),
                    new Vector2(0.50f,1),
                    // left face
                    new Vector2(0,third),
                    new Vector2(0,2 * third),
                    new Vector2(0.25f,third),
                    new Vector2(0.25f,2 * third),
                    // right face
                    new Vector2(0.5f,third),
                    new Vector2(0.5f,2 * third),
                    new Vector2(0.75f,third),
                    new Vector2(0.75f,2 * third),
                    // front face
                    new Vector2(0.25f,third),
                    new Vector2(0.25f,2 * third),
                    new Vector2(0.50f,third),
                    new Vector2(0.50f,2 * third),
                    // back face
                    new Vector2(0.75f,third),
                    new Vector2(0.75f,2 * third),
                    new Vector2(1,third),
                    new Vector2(1,2 * third),
                };
                s_UnitCube.triangles = new int[]
                {
                    // Bottom face
                    0, 1, 2,
                    2,1,3,

                    // Top face
                    4, 5, 6,
                    6,5, 7,

                    // Left face
                    8, 9, 10,
                    10,9, 11,

                    // Right face
                    12, 13, 14,
                    14,13,15,

                    // Front face
                    16, 17,18,
                    18,17,19,

                    // Back face
                    20, 21,22,
                    22, 21, 23,
                };
                s_UnitCube.RecalculateBounds();
                s_UnitCube.RecalculateNormals();
            }
            return s_UnitCube;
        }

    }

    public struct MeshData
    {
        public Vector3[] vertices;
        public Vector3[] normals;
        public int[] triangles;
    }

    public static Mesh Cylinder(int circumferencePoints, float topRadius, float bottomRadius, float height)
    {
        Mesh cylinderMesh = new Mesh();

        // Calculate the number of vertices needed for the cylinder
        int numVertices = circumferencePoints * 6 + 2;

        // Calculate the angle between each point on the circumference in radians
        float radiansBetweenCircumferencePoints = 2 * Mathf.PI / circumferencePoints;

        // Initialize arrays to hold the vertices, normals, and triangles of the cylinder mesh
        Vector3[] vertices = new Vector3[numVertices];
        Vector3[] normals = new Vector3[numVertices];
        int[] triangles = new int[circumferencePoints * 12];

        // Create top and bottom vertices and normals;
        vertices[0] = new Vector3(0, height, 0);
        vertices[1] = new Vector3(0, 0, 0);
        normals[0] = Vector3.up;
        normals[1] = Vector3.down;
        // Create Vertices, normals and triangles for the top
        for (int i = 0; i < circumferencePoints; i++)
        {
            float angle = radiansBetweenCircumferencePoints * i;
            vertices[i + 2] = new Vector3(topRadius * Mathf.Sin(angle), height, topRadius * Mathf.Cos(angle));
            normals[i + 2] = Vector3.up;
            triangles[i * 3] = (i % circumferencePoints) + 2;
            triangles[i * 3 + 1] = ((i + 1) % circumferencePoints) + 2;
            triangles[i * 3 + 2] = 0;

        }

        // Create Vertices, normals and triangles for the bottom
        for (int i = 0; i < circumferencePoints; i++)
        {
            float angle = radiansBetweenCircumferencePoints * i;
            vertices[i + circumferencePoints + 2] = new Vector3(bottomRadius * Mathf.Sin(angle), 0, bottomRadius * Mathf.Cos(angle));
            normals[i + 2 + circumferencePoints] = Vector3.down;
            triangles[(i + circumferencePoints) * 3] = (i % circumferencePoints) + 2 + circumferencePoints;
            triangles[(i + circumferencePoints) * 3 + 2] = ((i + 1) % circumferencePoints) + 2 + circumferencePoints;
            triangles[(i + circumferencePoints) * 3 + 1] = 1;
        }

        // Create Vertices, normals and triangles for the side
        for (int i = 0; i < circumferencePoints; i++)
        {
            float angle = radiansBetweenCircumferencePoints * i;

            vertices[i * 4 + circumferencePoints * 2 + 2] = new Vector3(topRadius * Mathf.Sin(angle), height, topRadius * Mathf.Cos(angle));
            vertices[i * 4 + circumferencePoints * 2 + 2 + 1] = new Vector3(bottomRadius * Mathf.Sin(angle), 0, bottomRadius * Mathf.Cos(angle));
            vertices[i * 4 + circumferencePoints * 2 + 2 + 2] = new Vector3(topRadius * Mathf.Sin(angle + radiansBetweenCircumferencePoints), height, topRadius * Mathf.Cos(angle + radiansBetweenCircumferencePoints));
            vertices[i * 4 + circumferencePoints * 2 + 2 + +3] = new Vector3(bottomRadius * Mathf.Sin(angle + radiansBetweenCircumferencePoints), 0, bottomRadius * Mathf.Cos(angle + radiansBetweenCircumferencePoints));
            for (int j = 0; j < 4; j++)
            {
                normals[i + circumferencePoints * 2 + 2 + j] = Vector3.Cross(vertices[i * 4 + circumferencePoints * 2 + 2], vertices[i * 4 + circumferencePoints * 2 + 2 + 1]);
            }
            triangles[(i + circumferencePoints) * 6] = i * 4 + circumferencePoints * 2 + 2;
            triangles[(i + circumferencePoints) * 6 + 2] = i * 4 + circumferencePoints * 2 + 2 + 2;
            triangles[(i + circumferencePoints) * 6 + 1] = i * 4 + circumferencePoints * 2 + 2 + 1;
            triangles[(i + circumferencePoints) * 6 + 3] = i * 4 + circumferencePoints * 2 + 2 + 1;
            triangles[(i + circumferencePoints) * 6 + 4] = i * 4 + circumferencePoints * 2 + 2 + 3;
            triangles[(i + circumferencePoints) * 6 + 5] = i * 4 + circumferencePoints * 2 + 2 + 2;
        }

        // Set the vertices, normals, and triangles of the cylinder mesh
        cylinderMesh.vertices = vertices;
        cylinderMesh.triangles = triangles;
        cylinderMesh.RecalculateBounds();
        cylinderMesh.RecalculateNormals();

        return cylinderMesh;
    }
    //public static MeshData Cylinder(int circumferencePoints, float topRadius, float bottomRadius, float height, bool returnas) //????????????? WIP could be a class of cylinder data which has a getter for the mesh object which makes the mesh object and a Getter for meshdata values.
    //{
    //    Mesh cylinderMesh = new Mesh();

    //    // Calculate the number of vertices needed for the cylinder
    //    int numVertices = circumferencePoints * 6 + 2;

    //    // Calculate the angle between each point on the circumference in radians
    //    float radiansBetweenCircumferencePoints = 2 * Mathf.PI / circumferencePoints;

    //    // Initialize arrays to hold the vertices, normals, and triangles of the cylinder mesh
    //    Vector3[] vertices = new Vector3[numVertices];
    //    Vector3[] normals = new Vector3[numVertices];
    //    int[] triangles = new int[circumferencePoints * 12];

    //    // Create top and bottom vertices and normals;
    //    vertices[0] = new Vector3(0, height, 0);
    //    vertices[1] = new Vector3(0, 0, 0);
    //    normals[0] = Vector3.up;
    //    normals[1] = Vector3.down;
    //    // Create Vertices, normals and triangles for the top
    //    for (int i = 0; i < circumferencePoints; i++)
    //    {
    //        float angle = radiansBetweenCircumferencePoints * i;
    //        vertices[i + 2] = new Vector3(topRadius * Mathf.Sin(angle), height, topRadius * Mathf.Cos(angle));
    //        normals[i + 2] = Vector3.up;
    //        triangles[i * 3] = (i % circumferencePoints) + 2;
    //        triangles[i * 3 + 1] = ((i + 1) % circumferencePoints) + 2;
    //        triangles[i * 3 + 2] = 0;

    //    }

    //    // Create Vertices, normals and triangles for the bottom
    //    for (int i = 0; i < circumferencePoints; i++)
    //    {
    //        float angle = radiansBetweenCircumferencePoints * i;
    //        vertices[i + circumferencePoints + 2] = new Vector3(bottomRadius * Mathf.Sin(angle), 0, bottomRadius * Mathf.Cos(angle));
    //        normals[i + 2 + circumferencePoints] = Vector3.down;
    //        triangles[(i + circumferencePoints) * 3] = (i % circumferencePoints) + 2 + circumferencePoints;
    //        triangles[(i + circumferencePoints) * 3 + 2] = ((i + 1) % circumferencePoints) + 2 + circumferencePoints;
    //        triangles[(i + circumferencePoints) * 3 + 1] = 1;
    //    }

    //    // Create Vertices, normals and triangles for the side
    //    for (int i = 0; i < circumferencePoints; i++)
    //    {
    //        float angle = radiansBetweenCircumferencePoints * i;

    //        vertices[i * 4 + circumferencePoints * 2 + 2] = new Vector3(topRadius * Mathf.Sin(angle), height, topRadius * Mathf.Cos(angle));
    //        vertices[i * 4 + circumferencePoints * 2 + 2 + 1] = new Vector3(bottomRadius * Mathf.Sin(angle), 0, bottomRadius * Mathf.Cos(angle));
    //        vertices[i * 4 + circumferencePoints * 2 + 2 + 2] = new Vector3(topRadius * Mathf.Sin(angle + radiansBetweenCircumferencePoints), height, topRadius * Mathf.Cos(angle + radiansBetweenCircumferencePoints));
    //        vertices[i * 4 + circumferencePoints * 2 + 2 + +3] = new Vector3(bottomRadius * Mathf.Sin(angle + radiansBetweenCircumferencePoints), 0, bottomRadius * Mathf.Cos(angle + radiansBetweenCircumferencePoints));
    //        for (int j = 0; j < 4; j++)
    //        {
    //            normals[i + circumferencePoints * 2 + 2 + j] = Vector3.Cross(vertices[i * 4 + circumferencePoints * 2 + 2], vertices[i * 4 + circumferencePoints * 2 + 2 + 1]);
    //        }
    //        triangles[(i + circumferencePoints) * 6] = i * 4 + circumferencePoints * 2 + 2;
    //        triangles[(i + circumferencePoints) * 6 + 2] = i * 4 + circumferencePoints * 2 + 2 + 2;
    //        triangles[(i + circumferencePoints) * 6 + 1] = i * 4 + circumferencePoints * 2 + 2 + 1;
    //        triangles[(i + circumferencePoints) * 6 + 3] = i * 4 + circumferencePoints * 2 + 2 + 1;
    //        triangles[(i + circumferencePoints) * 6 + 4] = i * 4 + circumferencePoints * 2 + 2 + 3;
    //        triangles[(i + circumferencePoints) * 6 + 5] = i * 4 + circumferencePoints * 2 + 2 + 2;
    //    }

    //    // Set the vertices, normals, and triangles of the cylinder mesh
    //    cylinderMesh.vertices = vertices;
    //    cylinderMesh.triangles = triangles;
    //    cylinderMesh.RecalculateBounds();
    //    cylinderMesh.RecalculateNormals();

    //    return cylinderMesh;
    //}
}
