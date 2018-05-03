using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class controllerScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void updateScore(long score){
		this.GetComponent<Text> ().text = "SCORE: " + score.ToString ();
	}
}
