using UnityEngine;
using System.Collections;
using System;
using SharpOSC;

/* This class is never instantiated, so everything is a static function */
public class Muse : MonoBehaviour {

	public UDPListener listener;

	/* muse information available to other scripts */

	public static int blinks = 0;
	public static int clenches = 0;	// Jaw clench count
	public static string mood = "content";
	public static int battery = 0;


	/* Constants for use with accelerometer data. */
	private const int UD = 0;		// Array access for up/down
	private const int FB = 1;		// Array access for front/back
	private const int LR = 2;		// Array access for left/right

	/* Accelerometer data. Listed in order of { UD, FB, LR }
	*  	UD: head up/down
	* 		FB: head front/back
	* 		LR: head left/right
	*/
	private static float[] acc_dt = { 0f, 0f, 0f };				// Delta time if min is below threshold and max is above.
	private static float[] acc_threshold = { 300f, 0f, 200f };	// Start detecting acceleration of head
	private static float[] acc_recent = { 0f, 0f, 0f };			// Most recently recorded position data

	void Start() 
	{
		// Callback function for received OSC messages.
		HandleOscPacket callback = delegate(OscPacket packet)
		{
			var messageReceived = (OscMessage)packet;
			var addr = messageReceived.Address;

			if(addr == "/muse/acc") {
				//head position and accleration
				float[] acc_data = { 
					(float)messageReceived.Arguments[0],
					(float)messageReceived.Arguments[1],
					(float)messageReceived.Arguments[2]
				};
				CallbackAcc(acc_data);
			}

			else if(addr == "/muse/elements/blink") {
				int blink = (int)messageReceived.Arguments[0];
				if (blink == 1) {
					blinks++;
				}
			}
				
			else if (addr == "/muse/elements/jaw_clench") {
				int clench = (int) messageReceived.Arguments[0];
				if (clench == 1) {
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
		};

		// Create an OSC server.
		listener = new UDPListener(5000, callback);

	}

	void Update() 
	{
		//reset public muse data
		blinks = 0;
		clenches = 0;
	}

	void OnApplicationQuit() 
	{
		listener.Close();
	}

	/*************************/
	/* PRIVATE CLASS METHODS */
	/*************************/

	/* Called when accelerometer data comes in from the accelerometer on the Muse.
	 * This updates variables accordingly.
	 *
	 * I intend to describe this further, but it's a hackathon project so...
	 * let's be real, I probably won't.
	 */
	private static void CallbackAcc(float[] acc_data)
	{
		for (int i = 0; i < 3; i++) {
			acc_recent[i] = acc_data[i];
			if (Math.Abs(acc_data[i]) > acc_threshold[i]) {
				acc_dt[i] += 1.0f;
			} else {
				acc_dt[i] = 0f;
			}

			if (i == LR) {
				print ("data");
				print (acc_data [i]);
				print (acc_dt [i]);
				print ("recent");
				print (acc_recent [i]);
			}
		}

	}

	// note: now I know why Input.GetAxis() uses string args.
	public static float GetVelocityUpDown()
	{
		// up is negative and down is positive which is counterintuitive,
		// so here we switch the sign
		float velocity = 0f;
		if (acc_dt[UD] > 0.0) {
			// Calculate slope
			velocity = -1.0f * Math.Abs((acc_recent[UD] - acc_threshold[UD]) / acc_dt[UD]);
		}
		return velocity;
	}

	public static float GetVelocityFrontBack()
	{
		// Front is negative and back is positive which is counterintuitive,
		// so here we switch the sign
		float velocity = 0f;
		if (acc_dt[FB] > 0.0) {
			// Calculate slope
			velocity = -1.0f * Math.Abs((acc_recent[FB] - acc_threshold[FB]) / acc_dt[FB]);
		}
		return velocity;
	}

	public static float GetVelocityLeftRight()
	{
		// Left is negative and right is positive which is intuitive,
		// so here we leave the sign as is.
		float velocity = 0f;
		if (acc_dt[LR] > 0.0) {
			// Calculate slope
			velocity = (acc_recent[LR] - acc_threshold[LR]) / acc_dt[LR];
		}
		return velocity;
	}
}	