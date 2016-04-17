using UnityEngine;
using System.Collections;
using System;
using SharpOSC;

public class Muse : MonoBehaviour {

	public UDPListener listener;

	void Start() 
	{
		// Callback function for received OSC messages. 
		// Prints EEG and Relative Alpha data only.
		//print("starting muse serv");
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
					print("blink!");
				}
			}
		};

		// Create an OSC server.
		listener = new UDPListener(5000, callback);

	}

	void Update() 
	{
		
	}

	void OnApplicationQuit() 
	{
		listener.Close();
	}
}	

