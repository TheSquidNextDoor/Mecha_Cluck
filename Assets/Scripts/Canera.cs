using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canera : MonoBehaviour
{
	private BoxCollider2D camMoveTrigger;
	[SerializeField] private GameObject player;

	//void Start() { camMoveTrigger = GetComponent<BoxCollider2D>(); }
	void Start()
	{
		camMoveTrigger = GetComponent<BoxCollider2D>();
	}

	void LateUpdate()
	{
		Vector3 offset = transform.position - player.transform.position;
		bool changeInX = false;
		Vector3 newCameraPosition = transform.position;
		if (offset.x < 3)
		{
			changeInX = true;
			newCameraPosition.x = (player.transform.position.x + offset.x) - (offset.x - 3);
		}
		if (!changeInX)
		{
			newCameraPosition.x = transform.position.x;
		}
		transform.position = newCameraPosition;
	}
}
