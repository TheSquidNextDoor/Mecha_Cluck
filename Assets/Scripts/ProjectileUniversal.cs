using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Universal 2d projectile controller by SibkoReject14085.
/// </summary>

public class ProjectileUniversal : MonoBehaviour
{
	public Rigidbody2D rb2D;

	public int pierceCount; //How many targets can this projectile pierce before despawning?
	public int damage; //How much damage does this projectile do on contact?
	public int gravity; //How much does gravity affect this projectile? -100 - 100.
	public float explodeRange; //Set to 0 if weapon type does not explode.

	void Start()
	{
		gameObject.SetActive(false); //Disable this object on spawn.
	}

	private void OnEnable()
	{
		rb2D.WakeUp();
		Invoke("ApplyGravity", 0.1f);
	}

	void ApplyGravity()
	{ rb2D.gravityScale = gravity / 100; }

	private void OnBecameInvisible()
	{
		gameObject.SetActive(false); //Projectiles despawn when off-screen.
		rb2D.Sleep();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == 10 || collision.gameObject.layer == 13) //10 is the enemy collision layer and 13 is the shootable projectile layer, so we check for those.
		{
			if (pierceCount > 0)
			{
				pierceCount--;
			}
			else
			{
				gameObject.SetActive(false); //Bullet returns to pool as it is not piercing anything.
			}
		}
		if (collision.gameObject.layer == 8) //8 is the ground layer.
		{ gameObject.SetActive(false); }
	}
}
