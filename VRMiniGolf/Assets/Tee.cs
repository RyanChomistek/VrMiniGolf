using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tee : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().centerOfMass = new Vector3(0, -2, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
