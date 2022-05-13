using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	aww heck, here we go again
	Guess what? Yet another movement script!
	By the quantum nanomachine computing cloud who set the repository up.
*/

public class Movement_Player : MonoBehaviour
{
	[Header("Ground Movement")]
	public float moveSpeed; //Speed of player when moving horizontally.

	[Space(10)]

	[Header("Jumping")]
	public float jumpHeight; //Initial velocity of player's jump.
	public float landingTime; //The amount of time after the player lands from a height before they can initiate another jump in seconds.
	public float coyoteTime; //Time the player can jump after walking off an edge in seconds.
	private bool canJump; //Checking if the player is able to jump.
	private float yVel; //Y velocity, used for jumping.

	//Components
	private CapsuleCollider2D mainCollider;
	private BoxCollider2D floorCollider; //This is for jump detection.
	private Rigidbody2D rb2D;

	//Run once code is stored in the void Start()
	void Start()
	{
		//Making the player object's components accessable to this.
		mainCollider = GetComponent<CapsuleCollider2D>();
		floorCollider = GetComponent<BoxCollider2D>();
		rb2D = GetComponent<Rigidbody2D>();
	}

	//Could you possibly guess what void Update() does?
	void Update()
	{
		//Horizontal Movement.
		Vector2 nextMove = new Vector2(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0); //This is easier to edit than a MovePosition argument.
		rb2D.MovePosition(rb2D.position + nextMove); //Physically moving the player. I use MovePosition instead of AddForce because I would like the player's movement to feel snappy and responsive, as this would improve game feel.

		if (Input.GetButton("Jump") && canJump) //I bet you can't POSSIBLY guess what this does!!
		{
			yVel = jumpHeight; //OR THIS!!!!
			canJump = false; //O R  T H I S ! ! ! ! ! !
		}
		if (floorCollider.IsTouchingLayers())
		{
			canJump = true;
		}
	}


}
