using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip[] LevelMusic;

    AudioSource m_audioSource;
    int m_lastMusicIndex;

    // Use this for initialization
    void Awake () {
        DontDestroyOnLoad(gameObject);

        m_audioSource = GetComponent<AudioSource>();
        m_lastMusicIndex = -1;
    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex < LevelMusic.Length &&
            LevelMusic[scene.buildIndex] != null)
        {
            if (m_lastMusicIndex != scene.buildIndex)
            {
                m_audioSource.clip = LevelMusic[scene.buildIndex];
                m_audioSource.loop = true;
                m_audioSource.Play();

                m_lastMusicIndex = scene.buildIndex;
            }
        }
    }

    public void SetVolume(float volume)
    {
        m_audioSource.volume = volume;
    }
}