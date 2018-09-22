using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignPost : MonoBehaviour {
    public Text Par;
    public Text ScoreFromPar;

	// Update is called once per frame
	void Update () {
        Par.text = "Par : " + GameManager.Instance.LevelPar;
        ScoreFromPar.text = "Score From Par : " + GameManager.Instance.CurrentScore;
    }
}
