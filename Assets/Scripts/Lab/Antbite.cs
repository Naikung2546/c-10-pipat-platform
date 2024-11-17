using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antbite : Weapon
{
    void Start()
    {
        Damage = 20;

    }
    public override void OnHitWith(Character character)
    {

        if (character is Player)
        {
            character.TakeDamage(this.Damage);
        }

    }

    public override void Move()
    {
        throw new System.NotImplementedException();
    }

}
