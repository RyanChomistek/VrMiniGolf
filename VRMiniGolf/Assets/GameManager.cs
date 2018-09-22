using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public int LevelPar = 1;
    public int NumHits = 0;
    public int CurrentScore { get{ return NumHits - LevelPar; } }

    public static GameManager Instance;

	// Use this for initialization
	void Awake() {
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
