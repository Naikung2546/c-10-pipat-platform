using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] int damage;
    public int Damage { get { return damage; } set { damage = value; } }
    protected IShootable shooter;

    //abstract methods
    public abstract void OnHitWith(Character character);

    public abstract void Move();


    public void Init(int _damage, IShootable _owner)
    {

        Damage = _damage;

        shooter = _owner;

    }

    private void OnTriggerEnter2D(Collider2D other) //add later
    {

        OnHitWith(other.GetComponent<Character>());

        Destroy(this.gameObject, 3f);

    }


    public int GetShootDirection() //to be modify
    {
        float shooterDir = shooter.BulletSpawnPoint.transform.position.x - shooter.BulletSpawnPoint.parent.position.x;
        if (shooterDir < 0)
            return -1;
        else
        return 1;

    }


    

}