using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemEft/Consumable/Th")]
public class ItemTHUpEffect : ItemEffect
{
    public int ThUpPoint = 0;
    public override bool ExecuteRole()
    {
        Debug.Log("th " + ThUpPoint + "up!");
        return true;

    }
}
