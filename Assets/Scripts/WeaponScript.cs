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
    private int level = 0;
    private int maxLevel = 2;
    private delegate void AttackMode(bool isEnemy);
    AttackMode currentAttack;

    private void Attack1(bool isEnemy)
    {
        print("ASDA1");
        if (CanAttack)
        {
            print("ASDA2");
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

    private void Attack2(bool isEnemy)
    {
    }

    private void Attack3(bool isEnemy)
    {
    }

    void Start()
    {
        currentAttack = Attack1;
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
        currentAttack(isEnemy);
    }


    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }

    public void LevelUp()
    {
        if (level < maxLevel)
        {
            level++;
        }  
    }
}
