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
//���̵� 14������ 16�� ����
[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : ScriptableObject // ���ӿ�����Ʈ�� �־����ʿ����..??
{
    
    //������ ����
    public ItemType itemType;
    //�������� �̹���
    public Sprite itemImage;
    // �������� �̸�
    public string itemName;
    //���� ����
    public string weaponType;

}
