using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {
	public GameObject gear1;
	public GameObject gear2;
	public GameObject gear3;
	public GameObject btnConfirm;
	public GameObject btnNext;
	public GameObject displayQuestions;
	public GameObject Timer;
	public GameObject hudScore;
	private long score;	
	private long totalScore;

	// Use this for initialization
	void Start () {
		this.score = 0;
		this.totalScore = 0;
		activeObjects ();
	}
	
	// Update is called once per frame
	void Update () {
		this.hudScore.GetComponent<controllerScore> ().updateScore(this.totalScore);
		if (this.Timer.GetComponent<timerController> ().getElapsedTime () <= 0) {
			this.checkSolution();
		}
	}
	public void loadObjects(){
		this.score = 0;
		this.activeObjects ();
		gear1.GetComponent<btnScript> ().reload ();
		gear2.GetComponent<btnScript> ().reload ();
		gear3.GetComponent<btnScript> ().reload ();
		displayQuestions.GetComponent<textChanger> ().reload ();
		Timer.GetComponent<timerController> ().reload ();		
	}

	public void checkSolution(){
		bool correct1 = true, correct2 = true, correct3 = true;
		if (this.gear1.GetComponent<btnScript> ().Type == displayQuestions.GetComponent<textChanger> ().Question1.Answer) {
			this.score = score + 10;
		} else {
			correct1 = false;
		}
		if (this.gear2.GetComponent<btnScript> ().Type == displayQuestions.GetComponent<textChanger>().Question2.Answer) {
			this.score = score+10;
		} else {
			correct2= false;			
		}
		if (this.gear3.GetComponent<btnScript> ().Type == displayQuestions.GetComponent<textChanger>().Question3.Answer) {
			this.score = score+10;
		} else {
			correct3 = false;			
		}
		this.totalScore += this.score * this.Timer.GetComponent<timerController> ().getElapsedTime ();
		this.gear1.GetComponent<btnScript> ().showAnswer(displayQuestions.GetComponent<textChanger> ().Question1.Answer, correct1);
		this.gear2.GetComponent<btnScript> ().showAnswer(displayQuestions.GetComponent<textChanger> ().Question2.Answer, correct2);
		this.gear3.GetComponent<btnScript> ().showAnswer(displayQuestions.GetComponent<textChanger> ().Question3.Answer, correct3);
		
		this.desativeObjects ();
	}
	private void activeObjects(){
		this.gear1.GetComponent<Button> ().interactable = true;
		this.gear2.GetComponent<Button> ().interactable = true;
		this.gear3.GetComponent<Button> ().interactable = true;
		this.btnConfirm.SetActive (true);
		this.btnNext.SetActive (false);		
	}
	private void desativeObjects(){
		this.gear1.GetComponent<Button> ().interactable = false;
		this.gear2.GetComponent<Button> ().interactable = false;
		this.gear3.GetComponent<Button> ().interactable = false;
		this.btnConfirm.SetActive (false);
		this.btnNext.SetActive (true);
		this.Timer.GetComponent<timerController> ().stop ();	

	}

}
