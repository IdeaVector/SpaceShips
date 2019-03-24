using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseScript : MonoBehaviour
{
    private void OnDestroy()
    {
        SceneManager.LoadScene(1);
    }
}
