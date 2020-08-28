using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] Bird bird;
    [SerializeField] float speed = 1;

    void Update()
    {
    	if(!bird.IsDead())
    	{
    		transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
    	}
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
    	Bird bird = collision.gameObject.GetComponent<Bird>();

    	if(bird)
    	{
    		Collider2D collider = GetComponent<Collider2D>();

    		if(collider)
    		{
    			collider.enabled = false;
    		}

    		bird.Dead();
    	}
    }

    public void Remove()
    {
        Destroy(gameObject);
    }
}
