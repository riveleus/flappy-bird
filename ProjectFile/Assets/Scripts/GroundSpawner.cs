using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class GroundSpawner : MonoBehaviour
{
    [SerializeField] Ground groundRef;
    private Ground prevGround;

    void SpawnGround()
    {
    	if(prevGround != null)
    	{
    		Ground newGround = Instantiate(groundRef);
    		newGround.gameObject.SetActive(true);
    		prevGround.SetNextGround(newGround.gameObject);
    	}
    }

    void OnTriggerExit2D(Collider2D collision)
    {
    	Ground ground = collision.GetComponent<Ground>();

    	if(ground)
    	{
    		prevGround = ground;
    		SpawnGround();
    	}
    }
}
