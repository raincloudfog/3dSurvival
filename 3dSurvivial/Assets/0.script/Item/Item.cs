using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equipment,
    material
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
