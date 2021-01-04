using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public string nextLevelName;
    // public float fadeDuration;
    // private Color black;

	// Use this for initialization
	/*void Start () {
        black = Color.black;
        FadeIn();
	}*/
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FadeToBlack()
    {
        // SteamVR_LoadLevel.Begin(nextLevelName, false, fadeDuration);

        SceneManager.LoadSceneAsync(SceneManager.GetSceneByName(nextLevelName).buildIndex, LoadSceneMode.Single);

    }

    /*public void FadeIn()
    {
        SteamVR_Fade.Start(black, fadeDuration, false);
    }*/
}
