using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    /// <summary>
    /// Всего хитпоинтов
    /// </summary>
    public int hp;
    public bool isEnemy = false;
    public GameObject hpSprite = null;
    private int maxHp;
    /// <summary>
    /// Наносим урон и проверяем должен ли объект быть уничтожен
    /// </summary>
    /// <param name="damageCount"></param>

    private void Start()
    {
        maxHp = hp;
        UpdateHp();
    }

    private void UpdateHp()
    {
        if (hpSprite != null)
        {
            hpSprite.transform.localScale = new Vector3((float)hp / (float)maxHp, 1, 1);
        }      
    }

    public void Damage(int damageCount, bool isFromPlayer1 = true)
    {
        hp -= damageCount;
        UpdateHp();

        if (hp <= 0)
        {
            // Смерть!
            if (isEnemy)
            {
                EnemyDestroyScript script = GetComponent<EnemyDestroyScript>();
                script.setFromPlayer1(isFromPlayer1);
            }
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
        if (shot != null && isEnemy != shot.isEnemyShot)
        {
            Damage(shot.damage, shot.isPlayer1);
            Destroy(shot.gameObject);
        }

    }
}
