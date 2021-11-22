using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSwitcher : MonoBehaviour
{
    public void Switch(int index)
    {
        SceneManager.LoadScene(index);
    }
}
