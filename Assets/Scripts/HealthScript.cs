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
    public Sprite hpSprite = null;
    /// <summary>
    /// Наносим урон и проверяем должен ли объект быть уничтожен
    /// </summary>
    /// <param name="damageCount"></param>

    public void Damage(int damageCount, bool isFromPlayer1 = true)
    {
        hp -= damageCount;

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
