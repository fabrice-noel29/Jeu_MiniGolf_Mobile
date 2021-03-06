﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootScript : MonoBehaviour
{
    public int nbShotsLeft;
    int power;
    public GameObject balle;
    public Text textNbShots;
    public Text txtPower;
    public Slider slider;
    public AudioClip son;
    public GameObject menuGameOver;

    public void Start()
    {
        textNbShots.text = "Shots: " + nbShotsLeft;
    }

    public void Shoot()
    {
        if (nbShotsLeft > 0)
        {
            power = (int)slider.value*25;
            nbShotsLeft--;
            textNbShots.text = "Shots: "+nbShotsLeft;
            balle.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward*power);
            balle.GetComponent<AudioSource>().PlayOneShot(son);
            slider.value = 0;
            StartCoroutine("LockSlider");
        }
        else
        {
            menuGameOver.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    IEnumerator LockSlider()
    {
        yield return new WaitForSeconds(0.2f);
        slider.interactable = false;
    }

    private void Update()
    {
        if((balle.GetComponent<Rigidbody>().velocity.magnitude < 0.2f)&&(slider.interactable==false))
        {
            slider.interactable = true;
        }
    }

    public void SetShotPower()
    {
        int val = (int)slider.value;
        txtPower.text = val + "%";
    }
}
