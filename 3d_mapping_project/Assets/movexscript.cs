using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports; 
public class movexscript : MonoBehaviour {
	public float speed;

	private float amounttoMove;

	SerialPort sp = new SerialPort("COM5", 9600);
		//SerialPort sp = new SerialPort("COM4", 9600);
	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 30;
		sp.Open ();
		sp.ReadTimeout = 16;
		print(sp.ReadByte());
	}
	
	// Update is called once per frame
	void Update () {
		
		amounttoMove = speed * Time.deltaTime;
		if (sp.IsOpen) {
			try 
			{
				dataHandler(sp.ReadByte());
				
				print(sp.ReadByte());
			
			}
			catch (System.Exception) {

				print("WEIRD but also sexy");
			}
		}

	}

	void dataHandler(int ByteData) {
		if (ByteData > 6)
		{
			ByteData = 0;
			print ("SHIT");
		}

		Movesphere (ByteData);		

	}

	void Movesphere(int ByteData ){
		if (ByteData == 1)
		{
			transform.Translate (Vector3.down * amounttoMove, Space.World); 
		}
		if (ByteData == 2) 
		{
			transform.Translate (Vector3.up * amounttoMove, Space.World);
		}
		if (ByteData == 3) 
		{
			transform.Translate (Vector3.right * amounttoMove, Space.World);
		}
		if (ByteData == 4) 
		{
			transform.Translate (Vector3.left * amounttoMove, Space.World);
		}
		//if (ByteData == 5) 
	//{
	//		transform.Rotate (Vector3.up * amounttoMove, Space.World);
	//	}
		if (ByteData == 6)  //bend sensor is idle
		{
			 transform.Rotate (Vector3.down * amounttoMove, Space.World);
			speed = 100;
		}

	}


}
