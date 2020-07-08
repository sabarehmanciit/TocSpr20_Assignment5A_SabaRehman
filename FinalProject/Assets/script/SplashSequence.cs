using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashSequence : MonoBehaviour
{

    public static int SceneNumber;
    // Use this for initialization
    void Start()
    {
        if (SceneNumber == 0)
        {
            StartCoroutine(SplashTwo());
        }
        if (SceneNumber == 1)
        {
            StartCoroutine(menu());
        }
    }

    private IEnumerator menu()
    {
        throw new NotImplementedException();
    }

    IEnumerator SplashTwo()
    {
        yield return new WaitForSeconds(5);
        SceneNumber = 1;
        SceneManager.LoadScene(1);
    }

    //IEnumerator Menu()
    //{
    //    yield return new WaitForSeconds(5);
    //    SceneNumber = 2;
    //    sceneManager.LoadScene(1);
    //}
}
