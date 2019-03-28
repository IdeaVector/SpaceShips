using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezyeMove : MonoBehaviour
{
    private BoxCollider2D box;
    private Vector3 startPosition;
    private Transform endTransform;
    private Vector3 endPosition;
    private Vector3 middlePostion;
    float t = 0;
    public float time = 4;
    public float rotationSpeed = 2;
    float step;

    // Start is called before the first frame update
    void Start()
    {
        step = 1/(time / Time.deltaTime);
        endTransform = GameObject.FindGameObjectWithTag("Base").transform;
        box = GameObject.FindGameObjectWithTag("EnemyMoveBox").GetComponent<BoxCollider2D>();
        startPosition = transform.position;
        endPosition = endTransform.position;
        float randX = Random.Range(-box.bounds.size.x / 2, box.bounds.size.x / 2);
        float randY = Random.Range(-box.bounds.size.y / 2, box.bounds.size.y / 2);
        middlePostion = new Vector3(randX, randY);
    }

    private Vector3 getBezye(float t)
    {
        Vector3 vector = new Vector3();

        vector = (1 - t) * (1 - t) * startPosition + 2 * t * (1 - t) * middlePostion + t * t * endPosition;

        return vector;
    }

    // Update is called once per frame
    void Update()
    {
        if (t < 1)
        {
            transform.position = getBezye(t);
            t += step;

            Vector3 vectorToTarget = endPosition - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle + 90.0F, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
        }     
    }  
}
