using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MWhatDoesNotBelong : MonoBehaviour
{
    SessionManager sessionManager;

    public void Practice()
    {
        SceneManager.LoadScene("WhatDoesNotBelong");
    }
}
