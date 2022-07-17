using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Pool;

/// <summary>
/// Universal 2d projectile controller by SibkoReject14085.
/// </summary>

public class ProjectileUniversal : MonoBehaviour
{
	private Action<ProjectileUniversal> _despawnAction;
	public Rigidbody2D rb2D;

	public int pierceCount; //How many targets can this projectile pierce before despawning?
	public int damage; //How much damage does this projectile do on contact?
	public int gravity; //How much does gravity affect this projectile?

	void Start()
	{
		gameObject.SetActive(false); //Disable this object on spawn.
		rb2D = GetComponent<Rigidbody2D>();
	}

	public void Init(Action<ProjectileUniversal> despawnAction)
	{
		_despawnAction = despawnAction;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.gameObject.layer == 11) //11 is the enemy collision layer, so we check that.
		{
			Debug.Log("Splat~!");
			if (pierceCount > 0)
			{

			}
			else
			{
				_despawnAction(this); //Bullet returns to pool as it is not piercing.
			}
		}
	}
}
