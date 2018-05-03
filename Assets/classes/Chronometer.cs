using System;
using System.Diagnostics;

public class Chronometer
{
	private Stopwatch timer;
	private long initialTime;
	private long elapsedTime;

	public Chronometer (long time){
		this.initialTime = time;
	}

	public void start(){
		this.timer = new Stopwatch ();
		this.timer.Start ();
	}
	public long getElapsedTime(){
		this.elapsedTime = (this.initialTime - this.timer.ElapsedMilliseconds - ((this.initialTime - this.timer.ElapsedMilliseconds)%10))/10;

		if (this.elapsedTime <= 0) {
			this.elapsedTime = 0;
			this.timer.Stop();
		}
		return this.elapsedTime;
	}

	public string ToString(){
		this.getElapsedTime ();
		long rightSide = this.elapsedTime % 100;
		long leftSide = (this.elapsedTime - rightSide)/100;
		string msg = leftSide.ToString () + ":" + rightSide.ToString ();
		if (leftSide < 10) {
			msg = "0"+msg;
		}
		if (rightSide < 10) {
			msg = msg+"0";
		}

		return msg;
	}
	public void stop(){
		this.timer.Stop ();
	}
}


