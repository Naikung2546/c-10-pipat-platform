using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] int damage;
    public int Damage { get { return damage; } set { damage = value; } }

    protected IShootable shooter;
    
    //abstract methods 
    public abstract void OnHitWith(Character character);
    public abstract void Move();

    public void Init (int _damage, IShootable _owner)
    {
        Damage = _damage;
        shooter = _owner;
    }

    public int GetShootDirection() //to be modify
    {
        float shootDir = shooter.BulletSpawnPoint.transform.position.x - shooter.BulletSpawnPoint.parent.transform.position.x;
        if (shootDir < 0) 
            return -1;
        else
            return 1;
    }


    private void OnTriggerEnter2D1(Collider2D other) // add later
    {
        OnHitWith(other.GetComponent<Character>());
        Destroy(other.gameObject, 5f);
    }
}
