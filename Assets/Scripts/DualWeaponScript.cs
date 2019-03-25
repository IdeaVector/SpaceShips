using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualWeaponScript : MonoBehaviour
{
    public Transform shotPrefab;
    public float shootingRate = 0.25f;
    public bool isShotUp = true;
    private float shootCooldown;

    void Start()
    {
        shootCooldown = 0f;
    }

    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }

    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            shootCooldown = shootingRate;

            // Создайте новый выстрел
            var shotTransformLeft = Instantiate(shotPrefab) as Transform;
            var shotTransformRight = Instantiate(shotPrefab) as Transform;

            // Определите положение
            shotTransformLeft.position = transform.position;
            shotTransformRight.position = transform.position;

            // Свойство врага
            ShotScript shot = shotTransformLeft.gameObject.GetComponent<ShotScript>();
            if (shot != null)
            {
                shot.isEnemyShot = isEnemy;
            }

            // Сделайте так, чтобы выстрел всегда был направлен на него
            MoveScript moveLeft = shotTransformLeft.gameObject.GetComponent<MoveScript>();
            MoveScript moveRight = shotTransformRight.gameObject.GetComponent<MoveScript>();
            if (moveLeft != null && moveRight != null)
            {
                int coef = 1;
                if (!isShotUp)
                {
                    coef *= -1;
                }
                moveRight.direction = transform.up * coef;
                moveRight.direction.x = -moveRight.direction.y;
                moveLeft.direction = transform.up * coef;
                moveLeft.direction.x = moveLeft.direction.y;
            }
        }
    }

    /// <summary>
    /// Готово ли оружие выпустить новый снаряд?
    /// </summary>
    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }
}
