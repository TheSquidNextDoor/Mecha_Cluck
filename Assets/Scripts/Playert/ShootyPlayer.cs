using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This manages shooting actions and swappable weapon logic.
/// </summary>

public class ShootyPlayer : MonoBehaviour
{
	public string WeaponType;
	public Vector2 iniVel;
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

	//You know what void Start() does.
	void Start()
	{
		
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

	IEnumerator Shootenany()
	{
		Vector2 initialVelocity = new Vector2(iniVel.x, iniVel.y + Random.Range(-inaccuracy, inaccuracy));
		yield return new WaitForSeconds(60 / BooletsPerMinute);

		if (Input.GetButton(shootenany))
		{
			ProjectilePooling.Instance.SpawnFromPool("Player Projectile", transform.position, initialVelocity, pierceCount, damage, gravity, explodeRange);
			StartCoroutine("Shootenany");
		}
		else isShootenanning = false;
	}
}
