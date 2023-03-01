using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool onPlank;
    public bool onWater;
    public int Health;
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
        onPlank = false;
        Health = 3;
    }

    private void Update()
    {
        if (Health == 0)
        {
            Time.timeScale = 0;
        }
    }
}
