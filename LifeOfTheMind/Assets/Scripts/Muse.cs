using UnityEngine;
using System.Collections;
using System;
using SharpOSC;

public class Muse : MonoBehaviour {

	public UDPListener listener;

	/* muse information available to other scripts */

	/* acc(0) == up/down
	 * y+ == down
	 * y- == up 
	*/
	/* acc(2) = left/right
	 * x+ == right
	 * x- == left
	 */
	public static float acc_x = 0;
	public static float acc_y = 0;
	//TODO(emmi): consider adding acc_z (acc(1)), unlikely that we'll use
	public static int blinks = 0;
	public static int clenches = 0;	// Jaw clench count
	public static string mood = "content";

	/* headset data */
	public static int battery = 0;

	void Start() 
	{
		// Callback function for received OSC messages. 
		print("starting muse serv");

		HandleOscPacket callback = delegate(OscPacket packet)
		{
			var messageReceived = (OscMessage)packet;
			var addr = messageReceived.Address;

			if(addr == "/muse/acc") {
				//head position and accleration
				float temp_acc_y = (float)messageReceived.Arguments[0];
				if (temp_acc_y < -300.0) {
					//head up
					acc_y = temp_acc_y;
				} else if (temp_acc_y > 300.0) {
					//head down
					acc_y = temp_acc_y;
				}
				float temp_acc_x = (float)messageReceived.Arguments[2];
				if (temp_acc_x < -200.0) {
					//head left
					acc_x = temp_acc_x;
				} else if (temp_acc_x > 200.0) {
					//head right
					acc_x = temp_acc_x;
				}
			}

			if(addr == "/muse/elements/blink") {
				int blink = (int)messageReceived.Arguments[0];
				if (blink == 1) {
					blinks++;
				}
			}
				
			else if (addr == "/muse/elements/jaw_clench") {
				bool clench = (bool) messageReceived.Arguments[0];
				if (clench) {
					clenches++;
				}
			}

			if(addr == "/muse/elements/experimental/concentration") {
				float focus = (float)messageReceived.Arguments[0];

				if (focus >= 0.75 && mood != "studious") {
					mood = "studious";
					print("mood update: studious");
				} else if (focus < 0.75  && mood == "studious") {
					mood = "content";
					print("mood update: content");
				}
			}

			if(addr == "/muse/elements/experimental/mellow") {
				float mellow = (float)messageReceived.Arguments[0];

				if (mellow >= 0.75 && mood == "content") {
					mood = "mellow";
					print("mood update: mellow");
				} else if (mellow < 0.75  && mood == "mellow") {
					mood = "content";
					print("mood update: content");
				}
			}

			if(addr == "/muse/batt") {
				if (battery != (int)messageReceived.Arguments[0]) {
					battery = (int)messageReceived.Arguments[0];
				}
			}

		// Create an OSC server.
		listener = new UDPListener(5000, callback);

	}

	void Update() 
	{
		clenches = 0;
		//reset public muse data
		blinks = 0;
		acc_y = 0;
		acc_x = 0;
	}

	void OnApplicationQuit() 
	{
		listener.Close();
	}
}	

