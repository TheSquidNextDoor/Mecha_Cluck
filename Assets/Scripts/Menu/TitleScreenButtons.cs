using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreenButtons : MonoBehaviour
{
	[SerializeField] private Button button;
	[SerializeField] private string type;

	private void OnMouseUpAsButton()
	{
		if (type == "Start")
		{
			//todo
		}
		if (type == "Exit")
		{
			Application.Quit();
		}
	}
}
