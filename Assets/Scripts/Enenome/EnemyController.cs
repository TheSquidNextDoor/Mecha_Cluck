using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int hitPoints; //How many hit points does this enemy have? Most mooks have 1.

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hitPoints <= 0)
		{
            gameObject.SetActive(false); //Temporary.
		}
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == 11) //11 is the player projectile layer.
		{
            hitPoints -= collision.gameObject.GetComponent<ProjectileUniversal>().damage; //Uhhh this is inefficient but I'm unaware of any other methods for dynamically changing values from a lot of different objects.
		}
	}
}
