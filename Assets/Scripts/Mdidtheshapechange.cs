using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mdidtheshapechange : MonoBehaviour
{
    SessionManager sessionManager;

    public void Practice()
    {
        //sessionManager = FindObjectOfType<SessionManager>();
        //sessionManager.StartSession();
        SceneManager.LoadScene("DidTheShapeChangeGame");
    }
}
