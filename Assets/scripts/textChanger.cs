using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class textChanger : MonoBehaviour
{
	public GameObject btnLeft;
	public GameObject btnRight;
	public Text txtQuestions;
	private int idQuestion;
	private List<Question> allQuestions;
	private Question question1;
	private Question question2;
	private Question question3;
	// Use this for initialization
	void Start ()
	{
		int choosedQuestion;
		idQuestion = 0;
		this.allQuestions = XmlInterface.loadQuestions ();

		choosedQuestion = Random.Range (0, this.allQuestions.Count - 1);
		this.question1 = allQuestions [choosedQuestion];
		this.allQuestions.RemoveAt (choosedQuestion);

		choosedQuestion = Random.Range (0, this.allQuestions.Count - 1);
		this.question2 = allQuestions [choosedQuestion];
		this.allQuestions.RemoveAt (choosedQuestion);

		choosedQuestion = Random.Range (0, this.allQuestions.Count - 1);
		this.question3 = allQuestions [choosedQuestion];
		this.allQuestions.RemoveAt (choosedQuestion);
	}
	public void reload(){
		this.Start ();
	}
	// Update is called once per frame
	void Update ()
	{
		loadQuestionById ();
	}
	private void loadQuestionById(){
		idQuestion = idQuestion % 3;
		switch (idQuestion) {
		case 0:
			txtQuestions.text = question1.TxtQuestion;
			break;
		case 1:
			txtQuestions.text = question2.TxtQuestion;
			break;
		case 2:
			txtQuestions.text = question3.TxtQuestion;
			break;
		}
		txtQuestions.text = (idQuestion + 1).ToString ()+" - "+ txtQuestions.text ;
	}
	public void next(){
		idQuestion++;
	}
	public void previous(){
		if(idQuestion == 0){
			idQuestion = 2;
		}else{
			idQuestion--;
		}
	}
	public void desactiveButtons(){
		this.btnLeft.GetComponent<Button> ().interactable = false;
		this.btnRight.GetComponent<Button> ().interactable = false;
	}
	public void activeButtons(){
		this.btnLeft.GetComponent<Button> ().interactable = true;
		this.btnRight.GetComponent<Button> ().interactable = true;
	}
	public Question Question1{
		get{
			return this.question1;
		}
	}
	public Question Question2{
		get{
			return this.question2;
		}
	}
	public Question Question3{
		get{
			return this.question3;
		}
	}
}

