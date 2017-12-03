using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [SerializeField]
    float TimeLimit = 300;

    [SerializeField]
    Slider timeSlider;

    [SerializeField]
    Canvas DeathPanel;

    [SerializeField]
    public bool hasKey;

	// Use this for initialization
	void Start ()
    {
        Time.timeScale = 1;
        timeSlider.maxValue = TimeLimit;
        timeSlider.value = timeSlider.maxValue;
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateSlider();
        UpdateDeath();
	}

    void UpdateSlider()
    {
        TimeLimit -= Time.deltaTime;
        timeSlider.value = TimeLimit;
    }

    void UpdateDeath()
    {
        if(TimeLimit <= 0)
        {
            DeathPanel.enabled = true;
            Time.timeScale = 0;
        }
    }
}
