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
	[SerializeField]
	private string currentBehaviour; //Current action the enemy is taking.

	[SerializeField]
	private string specialAction; //Does this enemy perform any special actions whilst idle?
	[SerializeField]
	private int personality; //What special trait does this enemy have? Brave, cowardly, etc.

	private Vector2[] bézierCurvePoints; //Quadratic Bézier curves require a start, end and a handle.

	private SpriteRenderer sr;

	// Start is called before the first frame update
	void Start()
	{
		bézierCurvePoints = new Vector2[2]; //Arrays start at 0 in unity so this array has 3 elements. Guess what needs 3 points?
	}

	// Update is called once per frame
	void Update()
	{
		if (hitPoints <= 0)
		{
			gameObject.SetActive(false); //Temporary. Waiting for assets.
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
				bézierCurvePoints[0] = transform.position; //Position of this enemy.
				bézierCurvePoints[1] = jumpTriggers.connectedTriggers[choosyMajigga].gameObject.transform.position; //Position of this enemy's destination.
				bézierCurvePoints[2] = (bézierCurvePoints[0] + bézierCurvePoints[1]) / 2; //Position of the handle. FINISH THIS LATER PLZZ!!!!! Need to calculate additional height.
			}
		}
		if (collision.gameObject.layer == 15) //15 is the jump down trigger. This enemy will jump down to the ground or another platform when passing through this trigger.
		{

		}
	}
}
