using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="LevelChunkData")]
public class LevelChunkData : ScriptableObject
{
    public enum Direction
    {
        North, East, West, South
    }
    public Vector2 chunkSize = new Vector2(5f, 5f);

    public GameObject[] levelChunks;
    public Direction entryDirection;
    public Direction exitDirection;
}
