using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolume : MonoBehaviour {

    private MusicManager m_musicManager;

	// Use this for initialization
	void Start () {
        m_musicManager = FindObjectOfType<MusicManager>();

        m_musicManager.SetVolume(PlayerPrefsManager.GetMasterVolume());
	}
}
