using UnityEngine;
using System.Collections;
using UnityEngine.UI; //so we can access UI elements
[ExecuteInEditMode] //so we can update even when the code is running.

public class UITextHero : MonoBehaviour 
{
	private PlayerInventory playerInventory;
	public int playerEnergy;

	// Use this for initialization
	void Awake () 
	{
		playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		playerEnergy = playerInventory.collectedEnergy;
		GetComponent<Text>().text = playerEnergy.ToString ();
	}
}
