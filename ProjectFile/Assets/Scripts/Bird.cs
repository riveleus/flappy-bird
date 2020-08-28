using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Bird : MonoBehaviour
{
    [SerializeField] float upForce = 100;
    [SerializeField] bool isDead;
    [SerializeField] int score;
    [SerializeField] TextMeshProUGUI scoreText;
	[SerializeField] Transform firePoint;
    [SerializeField] GameObject bullet;
    [SerializeField] UnityEvent OnJump, OnDead, OnShoot;
    [SerializeField] UnityEvent OnAddPoint;
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isDead)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Jump();
            }

			if(Input.GetMouseButtonDown(1))
			{
				Shoot();
			}
        }
    }

	void Shoot()
	{
		Instantiate(bullet, firePoint);

		if(OnShoot != null)
		{
			OnShoot.Invoke();
		}
	}

    public bool IsDead()
    {
        return isDead;
    }

    public void Dead()
    {
        if (!isDead && OnDead != null)
        {
            OnDead.Invoke();
        }

        isDead = true;
    }

    void Jump()
    {
        if (rb)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, upForce));
        }

        if (OnJump != null)
        {
            OnJump.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.enabled = false;
    }

    public void AddScore(int value)
    {
        scoreText.text = score.ToString();
        score += value;

        if (OnAddPoint != null)
        {
            OnAddPoint.Invoke();
        }
    }
}
