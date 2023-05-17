
using UnityEngine;

public class Block
{
    public int Id;
    public int SideIndex, DownIndex, UpIndex;


    public Block(int Id, int SideIndex, int DownIndex, int UpIndex)
    {
        this.Id = Id;
        this.SideIndex = SideIndex;
        this.DownIndex = DownIndex;
        this.UpIndex = UpIndex;
    }
}


