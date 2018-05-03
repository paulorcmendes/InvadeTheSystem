using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timerController : MonoBehaviour
{
	public Text textTimer;	
	public int time;
	private Chronometer chronometer;
	// Use this for initialization
	void Start ()
	{
		this.chronometer = new Chronometer (this.time);
		this.chronometer.start ();
	}
	public void reload(){
		this.Start ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.textTimer.text = this.chronometer.ToString();
	}
	public void stop(){
		this.chronometer.stop ();
	}
	public long getElapsedTime(){
		return chronometer.getElapsedTime ();
	}
}

