﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //untuk ke level 1
    public void prevScene()
    {
        SceneManager.LoadScene("Level1");
    }
    //level 2
    public void nextScene()
    {
        SceneManager.LoadScene("Level2");
    }
}
