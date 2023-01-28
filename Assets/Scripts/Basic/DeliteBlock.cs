using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliteBlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject block1 = GameObject.Find("Block1");

        Destroy(block1);

        GameObject[] blocks = GameObject.FindGameObjectsWithTag("BlockToDelite");

        foreach (var block in blocks)
        {
            block.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

   
    void Update()
    {
        
    }
}
