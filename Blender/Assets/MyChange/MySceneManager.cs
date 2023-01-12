using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MySceneManager : MonoBehaviour
{
    public void DieScene()
    {
        StartCoroutine("ChangeScene");
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("HorrorPacMan");
    }
}
