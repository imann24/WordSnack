﻿using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	public Texture2D[] instructions = new Texture2D[5];
	MeshRenderer m;
	Vector3 pos;
	Vector3 parentPos;
	Transform trash;
	Rect checkBox;
	wordBuildingController w;
	GameObject character1;
	GameObject character2;

	// Use this for initialization
	void Start () {
		m = gameObject.GetComponent<MeshRenderer> ();
		m.renderer.material.mainTexture = instructions[0];
		pos = transform.localPosition;
		parentPos = transform.parent.transform.position;
		trash = GameObject.Find ("TrashCharacter").transform;
		checkBox = new Rect (Screen.width * 0.32f, Screen.height * 0.54f, Screen.width * 0.04f, Screen.height * 0.055f);
		w = GameObject.Find ("GameController").GetComponent<wordBuildingController> ();
		character1 = w.character1;
		character2 = w.character2;
	}

	void Update(){
		// the first instruction box will slide in from the top
		if (pos.z <= -0.41f) {
			pos.z += Time.deltaTime*8.0f;
			transform.localPosition = pos;
		}
	}
	
	// Update is called once per frame
	void OnMouseDown () {
		// 0 = how to make a work instruction
		// 1 = trashcan function
	    // 2 = tap to feed customers message
		// 3 = how to end game + blank "don't show up again" box
		// 4 = how to end game + checked "don't show up again" box
		if(m.renderer.material.mainTexture == instructions[0]){
			m.renderer.material.mainTexture = instructions[1];
			transform.localPosition = new Vector3(-1.05f, 0.429f, 0.51f);
			transform.localScale = new Vector3(0.55f, 1.21f, 0.53f);
			gameObject.GetComponent<BoxCollider>().center = new Vector3(1.87f, 0,-0.16f);
			trash.position = new Vector3(trash.position.x, trash.position.y, -2.12f);
		}else if(m.renderer.material.mainTexture == instructions[1]){
			m.renderer.material.mainTexture = instructions[2];
			transform.localPosition = new Vector3(-0.06f, 0.429f, 1.6f);
			transform.localScale = new Vector3(0.52f, 1.21f, 0.35f);
			trash.position = new Vector3(trash.position.x, trash.position.y, -1.12f);
			gameObject.GetComponent<BoxCollider>().size = new Vector3(gameObject.GetComponent<BoxCollider>().size.x, gameObject.GetComponent<BoxCollider>().size.y, 27.59f);
			gameObject.GetComponent<BoxCollider>().center = new Vector3(-0.04f, 0,-4.4f);
			character1.transform.localPosition = new Vector3(character1.transform.localPosition.x,character1.transform.localPosition.y, -1.8f);
			character2.transform.localPosition = new Vector3(character2.transform.localPosition.x,character2.transform.localPosition.y, -1.8f);
		}
		else if(m.renderer.material.mainTexture == instructions[2]){
			m.renderer.material.mainTexture = instructions[3];
			transform.localPosition = new Vector3(0.06f, 0.429f, 0.45f);
			transform.localScale = new Vector3(0.73f, 1.21f, 0.64f);
			character1.transform.localPosition = new Vector3(character1.transform.localPosition.x,character1.transform.localPosition.y, 1);
			character2.transform.localPosition = new Vector3(character2.transform.localPosition.x,character2.transform.localPosition.y, 1);
		}
		else if(m.renderer.material.mainTexture == instructions[3]){
			// for mouse clicks
			if(checkBox.Contains(new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y))){
				m.renderer.material.mainTexture = instructions[4];
				transform.localPosition = new Vector3(0.07f, 0.429f, 0.41f);
				transform.localScale = new Vector3(0.76f, 1.21f, 0.67f);
			}
			// for touch 
			else if(checkBox.Contains(new Vector2(Input.GetTouch(0).position.x, Screen.height - Input.GetTouch(0).position.y))){
				m.renderer.material.mainTexture = instructions[4];
				transform.localPosition = new Vector3(0.07f, 0.429f, 0.41f);
				transform.localScale = new Vector3(0.76f, 1.21f, 0.67f);
			}else{
				parentPos.x = -20.0f;
				transform.parent.transform.position = parentPos;
				PlayerPrefs.SetInt("instructions",0);
			}
		}else if(m.renderer.material.mainTexture == instructions[4]){
			// for mouse clicks
			if(checkBox.Contains(new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y))){
				m.renderer.material.mainTexture = instructions[3];
				transform.localPosition = new Vector3(0.06f, 0.429f, 0.45f);
				transform.localScale = new Vector3(0.73f, 1.21f, 0.64f);
			}
			// for touch
			else if(checkBox.Contains(new Vector2(Input.GetTouch(0).position.x, Screen.height - Input.GetTouch(0).position.y))){
				m.renderer.material.mainTexture = instructions[3];
				transform.localPosition = new Vector3(0.06f, 0.429f, 0.45f);
				transform.localScale = new Vector3(0.73f, 1.21f, 0.64f);
			}else{
				parentPos.x = -20.0f;
				transform.parent.transform.position = parentPos;
				PlayerPrefs.SetInt("instructions", 1);
			}
		}
	}
}
