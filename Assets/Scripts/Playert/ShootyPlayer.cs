using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This manages shooting actions and swappable weapon logic.
/// </summary>

public class ShootyPlayer : MonoBehaviour
{
	private SpriteRenderer sr;
	private Rigidbody2D pRb2d;

	public string WeaponType;
	public Vector2 iniVel; //Configured velocity for projectiles.
	private Vector2 pewVel; //Applied velocity for projectiles.
	private bool isShootenanning;

	//Boolet Statz
	public int pierceCount; //See ProjectileUniversal.cs.
	public int damage;
	public int gravity;
	public float explodeRange;

	//GUNS GUNS GUNS! CLICK BANG AND THEIR LIMBS FALL OFF!
	public float BooletsPerMinute; //How many projectiles your shootenanner spews out in a minute.
	public int ammo; //How much ammunition your weapon has. Can only be refilled by picking up a new weapon. Peashooter has infinite ammo.
	public float inaccuracy; //Shot deviation in m/s of elevation.
	public int shotCount; //How many shots are fired per shot instance?

	public int bombCount; //How many bombs is the player holding?
	public string bombType; //What type of bomb is the player holding?

	//You know what void Start() does.
	void Start()
	{
		sr = GetComponent<SpriteRenderer>();
		pRb2d = GetComponent<Rigidbody2D>();
	}

	private string shootenany = "Fire1";
	void Update()
	{
		if (Input.GetButtonDown(shootenany) && !isShootenanning)
		{
			isShootenanning = true;
			StartCoroutine("Shootenany");
		}
	}

	void CheckAmmo()
	{
		if (ammo <= 0)
		{
			pierceCount = 0; //Peashooter stats that you revert to after ammo is gone.
			damage = 1;
			gravity = 0;
			explodeRange = 0;
			BooletsPerMinute = 240;
			inaccuracy = 0;
			shotCount = 1;
		}
	}

	IEnumerator Shootenany()
	{
		if (Input.GetButton(shootenany))
		{
			for (int i = 0; i < shotCount; i++)
			{
				if (sr.flipX)
				{ pewVel = new Vector2(-iniVel.x + pRb2d.velocity.x / 2, iniVel.y + (Random.Range(-inaccuracy * 100, inaccuracy * 100) / 100)); }
				else
				{ pewVel = new Vector2(iniVel.x + pRb2d.velocity.x / 2, iniVel.y + (Random.Range(-inaccuracy * 100, inaccuracy * 100) / 100)); }
				ProjectilePooling.Instance.SpawnFromPool("Player Projectile", transform.position, pewVel, pierceCount, damage, gravity, explodeRange);
			}
			ammo--; //Decrement ammo.
			CheckAmmo();
			yield return new WaitForSeconds(60 / BooletsPerMinute);
			StartCoroutine("Shootenany");
		}
		else isShootenanning = false;
	}
}
