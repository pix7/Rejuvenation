using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Practice1()
    {
        SceneManager.LoadScene("M-PickTheCardWithPictures");
    }
    public void Practice2()
    {
        SceneManager.LoadScene("M-DidTheShapeChange");
    }
    public void Practice3()
    {
        SceneManager.LoadScene("M-DoXEqualYGame");
    }
    public void Practice4()
    {
        SceneManager.LoadScene("M-WhatDoesNotBelong");
    }    
    public void Practice5()
    {
        SceneManager.LoadScene("M-ShortStory");
    }
}
