using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemEft/Consumable/ST")]
public class ItemSTUpEffect : ItemEffect
{
    public int StUpPoint = 0;
    public override bool ExecuteRole()
    {
        Debug.Log("st " + StUpPoint + "up!");
        return true;

    }
}


