using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public Transform shotPrefab;
    public float shootingRate = 0.25f;
    public bool isShotUp = true;
    public bool isPlayer1; 
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

            var shotTransform = Instantiate(shotPrefab) as Transform;

            shotTransform.position = transform.position;
            shotTransform.rotation = transform.rotation;

            ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
            if (shot != null)
            {
                shot.isEnemyShot = isEnemy;
                shot.isPlayer1 = isPlayer1;
            }
            
            MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
            if (move != null)
            {
                int coef = 1;
                if (!isShotUp)
                {
                    coef *= -1;
                }
                move.direction = coef * this.transform.up;
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
