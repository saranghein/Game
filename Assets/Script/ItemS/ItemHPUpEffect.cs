using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ItemEft/Consumable/Hp")]
public class ItemHPUpEffect : ItemEffect
{
    public int HpUpPoint = 0;
    public override bool ExecuteRole()
    {
        Debug.Log("hp " + HpUpPoint + "up");
        return true;

    }
}
