using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public int hitPoints; //How many hit points does this enemy have? Special enemies have more than 1.

	[SerializeField]
	private Vector2 patrolPos; //What position does this enemy want to stay by?
	public List<GameObject> squadMembers; //Who does this enemy stick by?
	public bool isSquadLeader;
	private string currentBehaviour; //Current action the enemy is taking.
	private Vector2 currentDestination;

	[SerializeField]
	private string specialAction; //Does this enemy perform any special actions whilst idle?
	[SerializeField]
	private int personality; //What special trait does this enemy have? Brave, cowardly, etc.

	private Vector2[] curvePoints; //3 point curve for jumping.
	private int jumpyThingyMaBob; //int i = 0;

	private SpriteRenderer sr;

	// Start is called before the first frame update
	void Start()
	{
		curvePoints = new Vector2[2]; //Arrays start at 0 in unity so this array has 3 elements. Guess what needs 3 points?
	}

	// Update is called once per frame
	void Update()
	{
		if (hitPoints <= 0)
		{
			gameObject.SetActive(false); //Temporary. Waiting for assets.
		}
		if(currentBehaviour!="idle")
		{
			Vector2.Lerp(transform.position, currentDestination, Time.deltaTime);
			if (currentBehaviour == "jump")
			{
				if(Vector2.Distance(transform.position, currentDestination) < 0.1f)
				{
					jumpyThingyMaBob++;
					currentDestination = curvePoints[jumpyThingyMaBob];
				}
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == 11) //11 is the player projectile layer.
		{
			hitPoints -= collision.gameObject.GetComponent<ProjectileUniversal>().damage; //Uhhh this is inefficient but I'm unaware of any other methods for dynamically changing values from a lot of different objects.
		}
		if (collision.gameObject.layer == 14) //14 is the jump up trigger. This enemy will jump up to a platform when passing through this trigger.
		{
			var jumpTriggers = collision.GetComponent<EnemyTriggerZones>(); //Getting the thingymabob, y'know! The thingymajigg! The whooby-whatzit!
			int choosyMajigga = Random.Range(0, jumpTriggers.connectedTriggers.Length);

			if(jumpTriggers.connectedTriggers[choosyMajigga].gameObject.layer == 15)
			{
				curvePoints[0] = transform.position; //Position of this enemy.
				curvePoints[1] = jumpTriggers.connectedTriggers[choosyMajigga].gameObject.transform.position; //Position of this enemy's destination.
				if (jumpTriggers.connectedTriggers[choosyMajigga].gameObject.transform.position.y < transform.position.y) //Position of the handle. Height is based off of something or idk.
				{
					curvePoints[2] = new Vector2(transform.position.x + curvePoints[1].x / 2, transform.position.y + (Vector2.Distance(curvePoints[1], transform.position) / 2));
				}
				else
				{
					curvePoints[2] = new Vector2(transform.position.x + curvePoints[1].x / 2, curvePoints[1].y + (Vector2.Distance(curvePoints[1], transform.position) / 2));
				}
			}
			currentBehaviour = "jump";
			jumpyThingyMaBob = 0;
		}
		if (collision.gameObject.layer == 15) //15 is the jump down trigger. This enemy will jump down to the ground or another platform when passing through this trigger.
		{

		}
	}
}
