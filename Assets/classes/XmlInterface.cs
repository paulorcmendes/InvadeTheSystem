using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Net;

public static class XmlInterface{
	private static string urlFile = "Assets\\xml\\dataBase.xml";
	private static string typeQuestion = "Question";
	private static string typeTxtQuestion = "txt";
	private static string typeAnswer = "answer";

	public static List<Question> loadQuestions(){
		List<Question> myQuestions = new List<Question>();
		ServicePointManager.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
		XmlReader reader = XmlReader.Create(urlFile);

		string txtQuestion, answer;
		while (reader.Read()) {
			if(reader.NodeType == XmlNodeType.Element && reader.Name == typeQuestion){
				txtQuestion = reader.GetAttribute(typeTxtQuestion);
				answer = reader.GetAttribute(typeAnswer);

				myQuestions.Add(new Question(txtQuestion, answer));
			}
		}

		return myQuestions;
	}
}
