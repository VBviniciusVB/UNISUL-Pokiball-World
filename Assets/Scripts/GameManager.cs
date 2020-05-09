﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool estaPausado = false;
    bool estaMutado = false;
    private AudioSource bgSound;
    public GameObject pause;
    public Image audioUI;
    private Text scoreText;
    private Image healthUI;
    public Sprite[] currentAudio;

    void Awake(){
        healthUI = GameObject.Find("HP").GetComponent<Image>();
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        bgSound = GameObject.Find("Music").GetComponent<AudioSource>();
    }

    void Start(){
        PlayerPrefs.SetInt("Fase", SceneManager.GetActiveScene().buildIndex);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if (!estaPausado) {
                pausar();
            } else {
                despausar();
            }
        }
    }

    public void resume(){
        estaPausado = false;
        pause.SetActive(false);
    }

    public void mute() {
        estaMutado = !estaMutado;
        if (!estaMutado) {
            audioUI.sprite = currentAudio[0];
            bgSound.Play();
        }
        else {
            audioUI.sprite = currentAudio[1];
            bgSound.Stop();
        }
    }

    public void exit(){
        PlayerPrefs.SetInt("Fase", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Menu");
    }

    public void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void nextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    void pausar(){
        estaPausado = true;
        pause.SetActive(true);
        scoreText.enabled = true;
        healthUI.enabled = true;
    }

    void despausar(){
        estaPausado = false;
        pause.SetActive(false);
        scoreText.enabled = false;
        healthUI.enabled = false;
    }

}
