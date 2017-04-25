using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevelAfter;

	// Use this for initialization
	void Awake () {
        DontDestroyOnLoad(gameObject);
	}
	
    void Start()
    {
        if (autoLoadNextLevelAfter > 0.0f)
        {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }
    }

    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
