﻿using UnityEngine;
using System.Collections;

public class TimedButtonHandler : MonoBehaviour {
	public bool buttonPressed = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		gameObject.renderer.material.color = Color.red;
	}
	void OnMouseUp()
	{
		gameObject.renderer.material.color = Color.white;
	}
	
	void OnMouseUpAsButton(){
		
		buttonPressed = true;
		PlayerPrefs.SetInt("timed",1);
		Application.LoadLevel("CharacterSelectTest");
	}
}