using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject[] RoadBlockPrefabs;
    public GameObject StartBlock;

    public float startblockxpos;
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
        startblockxpos = playertransform.transform.position.x + 27;
        for(int i = 0; i < blocksCount; i++)
        {
            SpawnBlock();

        }
        
    }

    
    void LateUpdate()
    {
        Check();
    }

    void Check()
    {
        if(CurrentBlocks[0].transform.position.x - playertransform.position.x < -40)
        {
            SpawnBlock();
            DestroyBlock();
        }
    }
    void SpawnBlock() {
        Vector3 blockpos;
        GameObject block = Instantiate(RoadBlockPrefabs[Random.Range(0,RoadBlockPrefabs.Length)], transform);
      if(CurrentBlocks.Count > 0)
        {
            blockpos = CurrentBlocks[CurrentBlocks.Count - 1].transform.position + new Vector3(blockLength , 0, 0);
        }
      else
        {
            blockpos = new Vector3(startblockxpos, 0, 0);
        }

        block.transform.position = blockpos;
        CurrentBlocks.Add(block);
    }

    void DestroyBlock()
    {
        Destroy(CurrentBlocks[0]);
        CurrentBlocks.RemoveAt(0);
    }
}
