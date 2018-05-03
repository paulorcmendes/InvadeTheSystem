
public class Question{
	private string txtQuestion;
	private string answer;

	public Question(string txtQuestion, string answer){
		this.txtQuestion = txtQuestion;
		this.answer = answer;
	}	
	public string TxtQuestion{
		get{
			return this.txtQuestion;
		}
	}
	public string Answer{
		get{
			return this.answer;
		}
	}
}
