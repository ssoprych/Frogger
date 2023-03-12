using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool onPlank;
    public bool onWater;
    public int Health;
    public bool OutOfScreen;
    public int Score;
    public int HousesVisited;
    public bool touchedHouse;
    public TMP_Text ScoreText;
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        onWater = false;
        onPlank = false;
        touchedHouse = false;
        OutOfScreen = false;
        Health = 3;
        HousesVisited = 0;
        Score = 0;
    }

    private void Update()
    {
        ScoreText.text = "Score: " + Score;
        if (HousesVisited == 3)
        {
            Time.timeScale = 0;
        }

        if (Health == 0)
        {
            Time.timeScale = 0;
        }
    }
}
