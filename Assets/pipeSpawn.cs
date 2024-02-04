using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeSpawn : MonoBehaviour
{
    public bird Bird;
    public GameObject pipe;
    public float spawnRate = 1;
    private float timer = 0;
    public float offSet = 4;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPipe();
        Bird = GameObject.FindGameObjectWithTag("bird").GetComponent<bird>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Bird.birdIsAlive)
        {
            if (timer < spawnRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                SpawnPipe();
                timer = 0;
            }
        }
    }
    void SpawnPipe()
    {
        float min = transform.position.y - offSet;
        float max = transform.position.y + offSet;
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(min, max)), transform.rotation);
    }
}
