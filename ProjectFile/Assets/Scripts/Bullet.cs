using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed;
	public Rigidbody2D rb;

    void Start()
    {
    	rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
    	Pipe pipe = other.GetComponent<Pipe>();
    	if(pipe != null)
    	{
    		pipe.Remove();
    		Destroy(gameObject);
    	}
    }
}
