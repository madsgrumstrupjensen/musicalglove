using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {

		}

	
	// Update is called once per frame
	void Update () {
		
		
	}
void OnTriggerEnter(Collider other)
{
	if(other.gameObject.tag=="bullet")
	speed = 0;    
}


}
