using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    public Slider m_volumeSlider;
    public Slider m_difficultySlider;
    public LevelManager m_levelManager;

    private MusicManager m_musicManager;

	// Use this for initialization
	void Start () {
        m_musicManager = FindObjectOfType<MusicManager>();

        m_volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        m_difficultySlider.value = PlayerPrefsManager.GetDifficulty();
    }
	
    void Update()
    {
        m_musicManager.SetVolume(m_volumeSlider.value);
    }

	public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(m_volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(m_difficultySlider.value);
        m_levelManager.LoadLevel("Menu");
    }

    public void SetDefaults()
    {
        m_volumeSlider.value = 0.8f;
        m_difficultySlider.value = 1.0f;
    }
}
