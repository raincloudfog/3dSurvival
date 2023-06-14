using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 아이템 타입들
/// </summary>
public enum ItemType
{
    Equipment, // 장비
    material, // 재료
    Food, // 음식


    End
}
//케이디 14강부터 16강 참조
[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : ScriptableObject // 게임오브젝트에 넣어줄필요없다..??
{
    
    //아이템 유형
    public ItemType itemType;
    //아이템의 이미지
    public Sprite itemImage;
    // 아이템의 이름
    public string itemName;
    //무기 유형
    public string weaponType;

}
