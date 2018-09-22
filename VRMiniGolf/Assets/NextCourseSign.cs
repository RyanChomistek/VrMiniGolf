using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextCourseSign : MonoBehaviour {

    public Text ScoreText;
    public string NextLevel;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ScoreText.text = "Your Score was : " + GameManager.Instance.CurrentScore;
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(NextLevel);
    }
}
