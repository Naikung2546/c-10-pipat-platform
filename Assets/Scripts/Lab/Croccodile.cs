using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Croccodile : Enemy, IShootable
{
    [SerializeField] private float attackRange;
    
    public Player player;


    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform BulletSpawnPoint { get; set; }
    [field: SerializeField] public float BulletSpawnTime { get; set; }
    [field: SerializeField] public float BulletTimer { get; set; }

   

    void Start()
    {
        Init(10);
        
        BulletTimer = 1.0f;
        BulletSpawnTime = 0.0f;
        player = GameObject.FindObjectOfType<Player>();
    }
    private void FixedUpdate()
    {
        BulletSpawnTime += Time.fixedDeltaTime;

        Behavior();
    }
    public override void Behavior()
    {
        Vector2 direction = player.transform.position - transform.position;

        if (direction.magnitude <= attackRange)
        {
            Shoot();
        }

    }
    public void Shoot()
    {
        if (BulletSpawnTime >= BulletTimer)
        {
            anim.SetTrigger("Shoot");
            GameObject obj = Instantiate(Bullet, BulletSpawnPoint.position, Quaternion.identity);
            Rock rock = obj.gameObject.GetComponent<Rock>();
            rock.Init(20, this);

            BulletSpawnTime = 0;
        }



    }
}