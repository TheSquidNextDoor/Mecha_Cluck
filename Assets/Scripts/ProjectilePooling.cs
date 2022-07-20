using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ProjectilePooling : MonoBehaviour
{
	[System.Serializable]
	public class Pool
	{
		public string tag;
		public ProjectileUniversal boolet;
		public int size;
	}

	public static ProjectilePooling Instance;

	private void Awake()
	{
		Instance = this;
	}

	public List<Pool> pools;
	public Dictionary<string, Queue<ProjectileUniversal>> poolDic;

	// Start is called before the first frame update
	void Start()
	{
		poolDic = new Dictionary<string, Queue<ProjectileUniversal>>();

		foreach (Pool pool in pools)
		{
			Queue<ProjectileUniversal> booletPoolet = new Queue<ProjectileUniversal>();
			for (int i = 0; i < pool.size; i++)
			{
				ProjectileUniversal booletto = Instantiate(pool.boolet);
				booletto.gameObject.SetActive(false);
				booletPoolet.Enqueue(booletto);
				booletto.transform.parent = transform; //Hierarchy tidyness.
			}

			poolDic.Add(pool.tag, booletPoolet);
			
			for (int j = 0; j < pool.size; j++)
			{
				SpawnFromPool(pool.tag, Vector2.zero, Vector2.zero, 0, 0, 0, 0); //Pre-spawning projectiles to make things work because of jank. It works, trust me.
			}
		}
	}

	public ProjectileUniversal SpawnFromPool (string tag, Vector2 pos, Vector2 velocity, int pierce, int damage, int gravity, float explodeRange) //This will return the projectile we want to get.
	{
		if (!poolDic.ContainsKey(tag)) { Debug.LogError("Pool w/ tag " + tag + " appears to be nonexistent. Please fix."); return null; }

		ProjectileUniversal booletToSpawn = poolDic[tag].Dequeue();

		booletToSpawn.gameObject.SetActive(true);
		booletToSpawn.rb2D.position = pos;
		booletToSpawn.rb2D.velocity = velocity;
		booletToSpawn.pierceCount = pierce;
		booletToSpawn.damage = damage;
		booletToSpawn.gravity = gravity;
		booletToSpawn.explodeRange = explodeRange;

		poolDic[tag].Enqueue(booletToSpawn);

		return booletToSpawn;
	}
}
