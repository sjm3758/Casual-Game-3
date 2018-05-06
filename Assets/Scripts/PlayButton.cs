using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {

    private Button btn;

	// Use this for initialization
	void Start () {
        btn = this.gameObject.GetComponent<Button>();
        btn.onClick.AddListener(LoadScene);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LoadScene()
    {
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            SceneManager.LoadScene("InstructionsScene");
        }
        if (SceneManager.GetActiveScene().name == "InstructionsScene")
        {
            SceneManager.LoadScene("PlayerTestScene");
        }
    }
}
