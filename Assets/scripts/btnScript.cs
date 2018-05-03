using UnityEngine;
using System.Collections;

public class btnScript : MonoBehaviour {
	private int state;
	private string type;
	public UnityEngine.UI.Text text;

	// Use this for initialization
	void Start () {
		text.color = new Color (0 , 214, 255);
		state = 0;
		transform.rotation = new Quaternion ();
	}
	public void reload(){
		this.Start ();
	}
	// Update is called once per frame
	void Update () {
		printType ();
	}

	public void vira(){
		this.state++;
		this.state = state % 4;
		updateRotation ();
	}
	private void updateRotation(){
		transform.rotation = new Quaternion ();
		transform.Rotate (0, 0, -90*state);
	}
	public void showAnswer(string type, bool correct){
		if (correct) {
			text.color = new Color (0, 255, 0);
		} else {
			text.color = new Color (255, 0, 0);
		}
		this.type = type;
		updateState ();
		updateRotation ();
	}
	public void updateState(){
		switch(this.type){
		case "bool":
			this.state = 0;
			break;
		case "int":
			this.state = 1;
			break;
		case "float":
			this.state = 2;
			break;
		case "char":
			this.state = 3;			
			break;
		default:
			//
			break;
		}
	}
	private void printType(){
		switch(state){
			case 0:
				type = "bool";
				break;
			case 1:
				type = "int";
				break;
			case 2:
				type = "float";
				break;
			case 3:
				type = "char";			
				break;
			default:
				type = "hue";
				break;
		}
		text.text = type;
	}
	public string Type{
		get{
			return this.type;
		}
	}
}
