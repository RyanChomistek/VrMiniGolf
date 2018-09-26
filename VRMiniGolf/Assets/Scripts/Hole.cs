using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hole : MonoBehaviour {

    public NextCourseSign NextCourse;
    public List<SteamVR_LaserPointer> Pointers;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponent<Ball>();
        if(ball)
        {
            NextCourse.gameObject.SetActive(true);
            GetComponent<AudioSource>().Play();
        }
    }
}
