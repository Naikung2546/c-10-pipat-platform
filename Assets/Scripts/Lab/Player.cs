using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character, IShootable
{
    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform BulletSpawnPoint { get; set; }
    [field: SerializeField] public float BulletSpawnTime { get; set; }
    [field: SerializeField] public float BulletTimer { get; set; }

    private void Update()
    {
        Shoot();
    }
    private void FixedUpdate()
    {
        BulletSpawnTime += Time.fixedDeltaTime;
    }

    public void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && BulletSpawnTime >= BulletTimer)
        {
            GameObject obj = Instantiate(Bullet, BulletSpawnPoint.position, Quaternion.identity);
            Banana banana = obj.GetComponent<Banana>();
            banana.Init(10, this);
            BulletSpawnTime = 0;
        }
    }
}
