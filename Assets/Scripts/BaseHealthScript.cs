using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealthScript : MonoBehaviour
{
    public Image bar;
    public Text health;
    public int hp;
    private int maxHp;

    private void Start()
    {
        maxHp = hp;
        UpdateHealth();
    }

    void UpdateHealth()
    {
        if (hp >= 0)
        {
            health.text = hp.ToString();
            bar.transform.localScale = new Vector3((float)hp / (float)maxHp, 1, 1);
        }
        else
        {
            health.text = "0";
        }
        
    }

    public void Damage(int damageCount)
    {
        hp -= damageCount;

        if (hp <= 0)
        {
            BaseScript script = GetComponent<BaseScript>();
            script.GameOver();
        }

        UpdateHealth();
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        EnemyDamage enemy = otherCollider.gameObject.GetComponent<EnemyDamage>();
        if (enemy != null)
        {
            Damage(enemy.damage);
            Destroy(enemy.gameObject);
        }
    }
}
