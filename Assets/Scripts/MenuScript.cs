using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
  public void OnClick()
    {
        print("hui");
        SceneManager.LoadScene("Main");
    }
}
