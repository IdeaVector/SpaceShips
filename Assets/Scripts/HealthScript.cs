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
    /// <summary>
    /// Наносим урон и проверяем должен ли объект быть уничтожен
    /// </summary>
    /// <param name="damageCount"></param>

    public void Damage(int damageCount)
    {
        hp -= damageCount;

        if (hp <= 0)
        {
            // Смерть!
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Это выстрел?
        if (!isEnemy)
        {
            EnemyMove enemy = otherCollider.gameObject.GetComponent<EnemyMove>();
            if (enemy != null)
            {
                Damage(enemy.damage);
                Destroy(enemy.gameObject);
            }
        }
        else
        {
            ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
            if (shot != null && isEnemy != shot.isEnemyShot)
            {
                print("ATTACKED");
                Damage(shot.damage);
                Destroy(shot.gameObject);
            }
        }  
    }
}
