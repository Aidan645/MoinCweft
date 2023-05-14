using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Facedata
{
    public Vector3Int[] Vertices;
    public int[] Triangles;
    public Facedata(Vector3Int[] verts, int[] tris)
    {
        Vertices = verts;
        Triangles = tris;
    }

}


public class ChunkMeshGeneration
{
    #region FaceData

    static readonly Vector3Int[] CheckDirections = new Vector3Int[]
    {
        Vector3Int.right,
        Vector3Int.left,
        Vector3Int.up,
        Vector3Int.down,
        Vector3Int.forward,
        Vector3Int.back
    };

    static readonly Vector3Int[] RightFace = new Vector3Int[]
    {
        new Vector3Int(1, 0, 0),
        new Vector3Int(1, 0, 1),
        new Vector3Int(1, 1, 1),
        new Vector3Int(1, 1, 0)
    };

    static readonly int[] RightTris = new int[]
    {
        0,2,1,0,3,2
    };

    static readonly Vector3Int[] LeftFace = new Vector3Int[]
    {
        new Vector3Int(0, 0, 0),
        new Vector3Int(0, 0, 1),
        new Vector3Int(0, 1, 1),
        new Vector3Int(0, 1, 0)
    };

    static readonly int[] LeftTris = new int[]
    {
        0,1,2,0,2,3
    };

    static readonly Vector3Int[] UpFace = new Vector3Int[]
    {
        new Vector3Int(0, 1, 0),
        new Vector3Int(0, 1, 1),
        new Vector3Int(1, 1, 1),
        new Vector3Int(1, 1, 0)
    };

    static readonly int[] UpTris = new int[]
    {
        0,1,2,0,2,3
    };

    static readonly Vector3Int[] DownFace = new Vector3Int[]
    {
        new Vector3Int(0, 0, 0),
        new Vector3Int(0, 0, 1),
        new Vector3Int(1, 0, 1),
        new Vector3Int(1, 0, 0)
    };

    static readonly int[] DownTris = new int[]
    {
        0,2,1,0,3,2
    };

    static readonly Vector3Int[] ForwardFace = new Vector3Int[]
    {
        new Vector3Int(0, 0, 1),
        new Vector3Int(0, 1, 1),
        new Vector3Int(1, 1, 1),
        new Vector3Int(1, 0, 1)
    };

    static readonly int[] ForwardTris = new int[]
    {
        0,2,1,0,3,2
    };

    static readonly Vector3Int[] BackFace = new Vector3Int[]
    {
        new Vector3Int(0, 0, 0),
        new Vector3Int(0, 1, 0),
        new Vector3Int(1, 1, 0),
        new Vector3Int(1, 0, 0)
    };

    static readonly int[] BackTris = new int[]
    {
        0,1,2,0,2,3
    };

    #endregion

    public static Dictionary<Vector3Int, Facedata> CubeFacesMap = new Dictionary<Vector3Int, Facedata>()
        {
            { Vector3Int.right, new Facedata(RightFace, RightTris) },
            { Vector3Int.left, new Facedata(LeftFace, LeftTris) },
            { Vector3Int.up, new Facedata(UpFace, UpTris) },
            { Vector3Int.down, new Facedata(DownFace, DownTris) },
            { Vector3Int.forward, new Facedata(ForwardFace, ForwardTris) },
            { Vector3Int.back, new Facedata(BackFace, BackTris) }
        };


    public static Mesh generateChunkMesh(Chunk chunk)
    {
        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();

        for (int x = 0; x < Chunk.CHUNK_SIZE; x++)
        {
            for (int y = 0; y < Chunk.CHUNK_HEIGHT; y++)
            {
                for (int z = 0; z < Chunk.CHUNK_SIZE; z++)
                {
                    Vector3Int pos = new Vector3Int(x, y, z);

                    foreach(Vector3Int direction in CheckDirections)
                    {
                        Vector3Int toCheck = pos + direction;

                        if (chunk.IsAir(pos) || !chunk.IsAir(toCheck)) continue;

                        foreach(Vector3Int vert in CubeFacesMap[direction].Vertices) vertices.Add(pos + vert + Chunk.CHUNK_SIZE*new Vector3Int(chunk.ChunkXPos,0,chunk.ChunkZPos));
                        foreach (int triIndex in CubeFacesMap[direction].Triangles) triangles.Add(vertices.Count - 4 + triIndex);

                    }
                    
                }
            }
        }
        Mesh res = new Mesh();
        res.SetVertices(vertices.ToArray());
        res.SetIndices(triangles.ToArray(), MeshTopology.Triangles, 0);

        res.RecalculateBounds();
        res.RecalculateNormals();
        res.RecalculateTangents();

        return res;
    }

}
