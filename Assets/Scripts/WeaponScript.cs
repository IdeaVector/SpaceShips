using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public Transform shotPrefab;
    public Transform rocketPrefab;
    public float shootingRate = 0.25f;
    public float rocketRate = 2f;
    public bool isShotUp = true;
    public bool isPlayer1;
    public GameObject leftWeapon;
    public GameObject rightWeapon;

    private float shootCooldown;
    private float rocketCooldown;
    private int level = 0;
    private int maxLevel = 3;
    private delegate void AttackMode(bool isEnemy);
    AttackMode currentAttack;

    private void Attack1(bool isEnemy)
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

    private void Attack2(bool isEnemy)
    {
        if (CanAttack)
        {
            shootCooldown = shootingRate;

            var shotTransform1 = Instantiate(shotPrefab) as Transform;
            var shotTransform2 = Instantiate(shotPrefab) as Transform;

            float angle = (Quaternion.Angle(transform.rotation, shotTransform2.rotation));
            shotTransform1.position = leftWeapon.transform.position;
            shotTransform2.position = rightWeapon.transform.position;
            shotTransform2.rotation = transform.rotation;
            shotTransform1.rotation = transform.rotation;

            ShotScript shot1 = shotTransform1.gameObject.GetComponent<ShotScript>();
            ShotScript shot2 = shotTransform2.gameObject.GetComponent<ShotScript>();
            if (shot1 != null && shot2 != null)
            {
                shot1.isEnemyShot = isEnemy;
                shot1.isPlayer1 = isPlayer1;
                shot2.isEnemyShot = isEnemy;
                shot2.isPlayer1 = isPlayer1;
            }

            MoveScript move1 = shotTransform1.gameObject.GetComponent<MoveScript>();
            MoveScript move2 = shotTransform2.gameObject.GetComponent<MoveScript>();
            if (move1 != null && move2 != null)
            {
                int coef = 1;
                if (!isShotUp)
                {
                    coef *= -1;
                }
                move1.direction = coef * this.transform.up;
                move2.direction = coef * this.transform.up;
            }
        }
    }

    private void Attack3(bool isEnemy)
    {
        Attack2(isEnemy);
        RocketAttack(isEnemy);
    }

    void Start()
    {
        LevelUp();
        shootCooldown = 0f;
    }

    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
        if (rocketCooldown > 0)
        {
            rocketCooldown -= Time.deltaTime;
        }
    }
    
    public void Attack(bool isEnemy)
    {
        currentAttack(isEnemy);
    }

    private void RocketAttack(bool isEnemy)
    {
        print("q");
        if (rocketCooldown <= 0)
        {
            print("q2");
            Instantiate(rocketPrefab, transform.position, Quaternion.identity);
            rocketCooldown = rocketRate;
        }
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
            switch (level)
            {
                case 1:
                    currentAttack = Attack1;
                    break;
                case 2:
                    currentAttack = Attack2;
                    break;
                default:
                    currentAttack = Attack3;
                    break;
            }
        }
    }
}
