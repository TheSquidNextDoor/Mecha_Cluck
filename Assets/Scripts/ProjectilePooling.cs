using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Pool;

public class ProjectilePooling : MonoBehaviour
{
	[SerializeField] private ProjectileUniversal projectile;
	private ObjectPool<ProjectileUniversal> booletPoolet;

	// Start is called before the first frame update
	void Start()
	{
		booletPoolet = new ObjectPool<ProjectileUniversal>(() => //Initialising the projectile object pool.
		{
			return Instantiate(projectile);
		}, projectile =>
		{
			projectile.gameObject.SetActive(true);
		}, projectile =>
		{
			projectile.gameObject.SetActive(false);
		}, projectile =>
		{
			Destroy(projectile.gameObject);
		}, true, 10, 20);

		Spawn(10); //Actually spawn the projectiles.
	}

	private void Spawn(int count)
	{
		for (var i = 0; i < count; i++)
		{
			var projectile = booletPoolet.Get();
			projectile.transform.SetParent(transform); //Parent newly spawned projectiles to the manager for scene tidyness.
			projectile.Init(DespawnAction);
		}
	}

	private void DespawnAction(ProjectileUniversal projctile)
	{
		booletPoolet.Release(projctile); //Return object to the pool.
	}

	public void Shootenany(int pierce, Vector2 velocity)
	{
		var pewpew = booletPoolet.Get();
		projectile.transform.SetParent(transform); //Parent newly spawned projectiles to the manager for scene tidyness.

		pewpew.Init(DespawnAction);
		pewpew.rb2D.AddForce(velocity, ForceMode2D.Impulse);
		pewpew.pierceCount = pierce;
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
