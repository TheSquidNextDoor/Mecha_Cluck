using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
	[SerializeField]
	private string weapon;
	[SerializeField]
	private ShootyPlayer pewScrip;

	// Start is called before the first frame update
	void Start()
	{
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == 9) //9 is the player's layer. This activates when the player enters this object's collider box.
		{
			ApplyGunStuff();
		}
	}

	private void ApplyGunStuff()
	{
		int pierce = 0;
		int owie = 0;
		int grav = 0;
		int kaboom = 0;
		float pewRate = 0;
		int ammOwO = 0;
		float devi = 0;
		int multishawt = 1;

		if (weapon == "HEAVY MACHINE GUN")
		{
			pierce = 0;
			owie = 1;
			grav = 0;
			kaboom = 0;
			pewRate = 1200;
			ammOwO = 300;
			devi = 0.25f;
			multishawt = 2;
		}
		if (weapon == "SHAWTGUHN")
		{
			pierce = 0;
			owie = 1;
			grav = 0;
			kaboom = 0;
			pewRate = 60;
			ammOwO = 25;
			devi = 1;
			multishawt = 12;
		}

		pewScrip.pierceCount = pierce;
		pewScrip.damage = owie;
		pewScrip.gravity = grav;
		pewScrip.explodeRange = kaboom;
		pewScrip.BooletsPerMinute = pewRate;
		pewScrip.ammo = ammOwO;
		pewScrip.inaccuracy = devi;
		pewScrip.shotCount = multishawt;

		Destroy(gameObject); //BEGONE!
	}
}
