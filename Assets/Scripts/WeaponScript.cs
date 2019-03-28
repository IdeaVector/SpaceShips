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
            shotTransform1.position = transform.position;
            //shotTransform1.position = new Vector3(transform.position.x - 0.2f * Mathf.Cos(90 - angle), transform.position.y - 0.2f * Mathf.Sin(90 - angle));
            shotTransform2.position = new Vector3(transform.position.x + 0.2f*Mathf.Cos(90 - angle), transform.position.y + 0.2f * Mathf.Sin(90 - angle));
            //print(angle);
            //print(Mathf.Cos(90 - angle));
            //print(Mathf.Sin(90 - angle));
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
            switch (level)
            {
                case 1:
                    currentAttack = Attack2;
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
