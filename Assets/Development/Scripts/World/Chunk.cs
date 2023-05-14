using UnityEngine;

public class Chunk
{
    
    public static int CHUNK_SIZE = 16;
    public static int CHUNK_HEIGHT = 16;

    public static int AIR = 0;

    public int[,,] Blocks;
    public int ChunkXPos;
    public int ChunkYPos;
    public Mesh Mesh;

    public Chunk(int[,,] blockTypes, int ChunkXPos, int ChunkYPos)
    {
        Blocks = new int[CHUNK_SIZE, CHUNK_SIZE, CHUNK_HEIGHT];
        this.ChunkXPos = ChunkXPos;
        this.ChunkYPos = ChunkYPos;

        for (int x = 0;x < CHUNK_SIZE; x++)
        {
            for(int y = 0;y < CHUNK_HEIGHT; y++)
            {
                for(int z = 0;z < CHUNK_SIZE; z++)
                {
                    Blocks[x, y, z] = blockTypes[x, y, z];
                }
            }
        }

        Mesh = ChunkMeshGeneration.generateChunkMesh(this);
    }


    public bool IsVisible(int x, int y, int z)
    {
        return IsAir(x + 1, y, z) || IsAir(x - 1, y, z) || IsAir(x, y + 1, z) || IsAir(x, y - 1, z) || IsAir(x, y, z - 1) || IsAir(x, y, z + 1);
    }

    public bool IsInBounds(int x, int y, int z)
    {
        return x < 0 || x >= CHUNK_SIZE || y < 0 || y >= CHUNK_HEIGHT || z < 0 || z >= CHUNK_SIZE;
    }

    public bool IsInBounds(Vector3Int pos)
    {
        return pos.x < 0 || pos.x >= CHUNK_SIZE || pos.y < 0 || pos.y >= CHUNK_HEIGHT || pos.z < 0 || pos.z >= CHUNK_SIZE;
    }

    public bool IsAir(int x, int y, int z)
    {
        return !IsInBounds(x,y,x) || Blocks[x, y, z] == AIR;
    }

    public bool IsAir(Vector3Int pos)
    {
        return !IsInBounds(pos) || Blocks[pos.x, pos.y,pos.z] == AIR;
    }
}

