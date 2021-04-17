using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject[] RoadBlockPrefabs;
    public GameObject StartBlock;

   public float blockxPos = 0;
   public int blocksCount = 7;
   float blockLength = 0;
    int safe = 120;
    public Transform playertransform;
    List<GameObject> CurrentBlocks = new List<GameObject>();
    void Start()
    {
        blockxPos = StartBlock.transform.position.x;
        blockLength = StartBlock.GetComponent<BoxCollider>().bounds.size.x;
        for(int i = 0; i < blocksCount; i++)
        {
            SpawnBlock();

        }
        
    }

    
    void Update()
    {
        Check();
    }

    void Check()
    {
        if(playertransform.transform.position.x - safe > (blockxPos - blocksCount * blockLength))
        {
            SpawnBlock();
            DestroyBlock();
        }
    }
    void SpawnBlock() {
        GameObject block = Instantiate(RoadBlockPrefabs[Random.Range(0,RoadBlockPrefabs.Length)], transform);
        blockxPos += blockLength;
        block.transform.position = new Vector3(blockxPos, 0, 0);
        CurrentBlocks.Add(block);
    }

    void DestroyBlock()
    {
        Destroy(CurrentBlocks[0]);
        CurrentBlocks.RemoveAt(0);
    }
}
