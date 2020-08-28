﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Destroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
    	Destroy(collision.gameObject);
    }
}
