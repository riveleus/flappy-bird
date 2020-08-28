using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] Bird bird;
    [SerializeField] Pipe pipeUp, pipeDown;
    private float holeSize;
    [SerializeField] float maxMinOffset = 1;
    [SerializeField] Point point;
    private Coroutine CR_Spawn;

    void Start()
    {
    	StartSpawn();
    }

    void StartSpawn()
    {
    	if(CR_Spawn == null)
    	{
    		CR_Spawn = StartCoroutine(IeSpawn());
    	}
    }

    void StopSpawn()
    {
    	if(CR_Spawn != null)
    	{
    		StopCoroutine(CR_Spawn);
    	}
    }

    void SpawnPipe()
    {
		holeSize = Random.Range(.8f, 2.5f);

    	Pipe newPipeUp = Instantiate(pipeUp, transform.position, Quaternion.Euler(0, 0, 180));
    	newPipeUp.gameObject.SetActive(true);

    	Pipe newPipeDown = Instantiate(pipeDown, transform.position, Quaternion.identity);
    	newPipeDown.gameObject.SetActive(true);

		Point newPoint = Instantiate(point, transform.position, Quaternion.identity);
    	newPoint.gameObject.SetActive(true);
    	newPoint.SetSize(holeSize);

    	newPipeUp.transform.position += Vector3.up * (holeSize / 2);
    	newPipeDown.transform.position += Vector3.down * (holeSize / 2);

    	float y = maxMinOffset * Mathf.Sin(Time.time);
    	newPipeUp.transform.position += Vector3.up * y;
    	newPipeDown.transform.position += Vector3.up * y;
    	newPoint.transform.position += Vector3.up * y;
    }

    IEnumerator IeSpawn()
    {
    	while(true)
    	{
    		if(bird.IsDead())
    		{
    			StopSpawn();
    		}

    		SpawnPipe();
    		yield return new WaitForSeconds(Random.Range(1.2f, 2.5f));
    	}
    }
}
