using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreRock : ObjectClass
{
    bool ishit = false;
    public override void PickUp()
    {
        if ((ishit == true || GameManager.Instance.isActive == false)
            || WeaponManager.Instance.weaponenum != WeaponManager.WeaponType.pickAxe)
        {
            return;
        }
        Hp -= 1;
        StartCoroutine(Delay());
        
        Debug.Log("±§ºÆ ∂ß∏≤");
        if (Hp <= 0)
        {
            Debug.Log("±§ºÆ ∫Œº≈¡¸");
            ObjectPool.Instance.ObjectsReturn(this);
        }
    }
    private void OnEnable()
    {
        Hp = 5; // Ω√¿€«ﬂ¿ª∂ß √º∑¬
        ishit = false;
    }
    IEnumerator Delay()
    {
        ishit = true;
        inventory.AcquireItem(_item, 1);
        if (ItemManager.Instance.items.ContainsKey(Materialtype.Rock))
        {
            if (ItemManager.Instance.items[Materialtype.Rock] >= 1)
            {
                ItemManager.Instance.items[Materialtype.Rock] += 1;
                Debug.Log("1¥ı«ÿ¡‹" + ItemManager.Instance.items[Materialtype.Bush]);
            }
        }

        else if (ItemManager.Instance.items.ContainsKey(Materialtype.Rock) == false)
        {
            ItemManager.Instance.items.Add(Materialtype.Rock, 1);
            Debug.Log("æ∆π´∞Õµµ æ¯æÓº≠ 1¥ı«ÿ¡‹" + ItemManager.Instance.items[Materialtype.Rock]);

        }
        yield return new WaitForSeconds(0.5f);
        ishit = false;
        yield break;
    }

}
