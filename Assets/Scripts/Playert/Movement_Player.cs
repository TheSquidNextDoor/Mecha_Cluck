using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	aww yeh, here we go again
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
	public bool canJump; //Checking if the player is able to jump.

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

	//FixedUpdate() is like Update() but synced to the physics or something.
	void FixedUpdate()
	{
		//Horizontal Movement.
		transform.Translate(Vector2.right * Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime); //Moving the player. No velocity for horizontal movement leads to more control.

		if (Input.GetButton("Jump") && canJump) //I bet you can't POSSIBLY guess what this does!!
		{
			canJump = false;
			rb2D.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse); //OR THIS!!!!
			StopCoroutine("CoyotyThyme"); //This is in case you walk off of a platform and land back on it before coyote time expires.
		}
	}

	private void OnCollisionEnter2D(Collision2D collision) //Checking if we've touched something.
	{
		if (floorCollider.IsTouching(collision.collider)) //Checking if we've touched the floor and are not holding the jump button.
		{
			StopCoroutine("CoyotyThyme"); //See above.
			canJump = true;
		}
	}

	private void OnCollisionStay2D(Collision2D collision)
	{ 
		if (!canJump && !Input.GetButton("Jump")) { canJump = true; } //Checks if the player is unable to jump and if they're not jumping already.
		//if (Input.GetAxis("Vertical") < 0.25) {  } was going to add ability to drop down platforms but i got lazy
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		StartCoroutine("CoyoteThyme");
	}

	IEnumerator CoyoteThyme()
	{
		yield return new WaitForSeconds(coyoteTime); //Wait for coyote time to expire
		canJump = false; //You cannot jump.
	}
}