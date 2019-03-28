using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawn : MonoBehaviour
{
    public GameObject[] bonuses;
    // Start is called before the first frame update
    void Start()
    {
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnBonus()
    {
        StartCoroutine(addBonus());
    }

    IEnumerator addBonus()
    {
        yield return new WaitForSeconds(1.0f);
        GameObject cr_bonus = bonuses[Random.Range(0, bonuses.Length)];
        float randX = Random.Range(-GetComponent<BoxCollider2D>().bounds.size.x / 2, GetComponent<BoxCollider2D>().bounds.size.x / 2);
        float randY = transform.position.y + Random.Range(-GetComponent<BoxCollider2D>().bounds.size.y / 2, GetComponent<BoxCollider2D>().bounds.size.y / 2);
        Vector2 bonusPosition = new Vector2(randX, randY);
        Instantiate(cr_bonus, bonusPosition, Quaternion.identity);
    }
}
