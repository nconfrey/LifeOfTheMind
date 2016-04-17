using UnityEngine;
using System.Collections;
using System;
using SharpOSC;

public class Muse : MonoBehaviour {

	public UDPListener listener;

	public static int blinks = 0;
	public static int clenches = 0;	// Jaw clench count

	void Start() 
	{
		// Callback function for received OSC messages. 
		// Prints EEG and Relative Alpha data only.
		print("starting muse serv");
		HandleOscPacket callback = delegate(OscPacket packet)
		{
			var messageReceived = (OscMessage)packet;
			var addr = messageReceived.Address;
			/*if(addr == "/muse/eeg") {
				print("EEG values: ");
				foreach(var arg in messageReceived.Arguments) {
					print(arg + " ");
				}
			}
			if(addr == "/muse/elements/alpha_relative") {
			print("Relative Alpha power values: ");
				foreach(var arg in messageReceived.Arguments) {
					print(arg + " ");
				}
			} */
			if(addr == "/muse/elements/blink") {
				int blink = (int)messageReceived.Arguments[0];
				if (blink == 1) {
					blinks++;
					print("blinks: " + blinks);
				}
			}

			// note: should we be doing "if" or "else if"? the example code
			//       just had ifs.. I suppose the real question is do we ever
			//       receive more than one address at a time? if we only
			//       receive one at a time, then we use "else if"'s. 
			else if (addr == "/muse/elements/jaw_clench") {
				bool clench = (bool) messageReceived.Arguments[0];
				if (clench) {
					clenches++;
				}
			}
		};

		// Create an OSC server.
		listener = new UDPListener(5000, callback);

	}

	void Update() 
	{
		clenches = 0;
	}

	void OnApplicationQuit() 
	{
		listener.Close();
	}
}	

