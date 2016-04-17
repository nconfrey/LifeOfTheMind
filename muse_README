SET-UP ==========================================
Follow along with http://developer.choosemuse.com/research-tools/getting-started
Basic steps in this developer guide 
	- install research tools
	- pair muse
	- work with muse.io to actually receive data
	- use muse lab to set up graphs and actually see that data

DATA =============================================
Muse uses electrodes to gather EEG data
http://developer.choosemuse.com/research-tools/available-data
	has specific write-ups of the data but is a little opaque

- EEG data
- Accelerometer data
- Also measures types of waves based on frequencies
	- delta
	- gamma
	- alpha 
	- beta
	- theta

 MUSE AND UNITY ==================================
 guided by http://developer.choosemuse.com/research-tools-example/grabbing-data-from-museio-a-few-simple-examples-of-muse-osc-servers#c#
 
 To actually use Muse data in Unity, we used an OSC server
 contained in Assests/Scripts/Muse.cs
 This script is attached to the main camera and receives a
 stream of Muse data over a UDP socket. 

 This requires running muse.io with a udp connection on the local machine
 Run muse-io --device Muse-XXXX --osc osc.udp://localhost:5000 
 where Muse-XXXX is your Muse device's name

