﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Point : MonoBehaviour
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

    public void SetSize(float size)
    {
    	BoxCollider2D collider = GetComponent<BoxCollider2D>();

    	if(collider != null)
    	{
    		collider.size = new Vector2(collider.size.x, size);
    	}
    }

    void OnTriggerExit2D(Collider2D collision)
    {
    	Bird bird = collision.gameObject.GetComponent<Bird>();

    	if(bird && !bird.IsDead())
    	{
    		bird.AddScore(1);
    	}
    }
}
