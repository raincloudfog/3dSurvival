using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ������ Ÿ�Ե�
/// </summary>
public enum ItemType
{
    Equipment, // ���
    material, // ���
    Food, // ����


    End
}
public enum ItemName
{ 
    Rock,
    Bush,
    Wood,
    Berry,
    PickAxe,
    Axe,


}
//���̵� 14������ 16�� ����
[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : ScriptableObject // ���ӿ�����Ʈ�� �־����ʿ����..??
{
    
    //������ ����
    public ItemType itemType;
    //�������� �̹���
    public Sprite itemImage;

    // �������� �̸�
    //public string itemName;
    public ItemName itemName;
    //���� ����
    public string weaponType;

}
