using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseScript : MonoBehaviour
{
    //private Rigidbody2D rb;

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        //rb.AddTorque(2f);
    }

    private void OnDestroy()
    {
        SceneManager.LoadScene(1);
    }
}
