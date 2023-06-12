using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum RecipeName
{
    axe,
    pickaxe,

}

public enum MaterialName
{
    Bush,
    Wood,
    Rock,

    End
}

public struct Recipe
{
    MaterialName mat;
    int count;

    public Recipe(MaterialName mat, int count)
    {
        this.mat = mat;
        this.count = count;
    }
}

public class RecipeScript : MonoBehaviour
{
    /// <summary>
    /// ����ϱ��� ������
    /// </summary>
    void Before()
    {
        // ��ᰡ ������� ���θ� �˻��� ��� �ϰ� �� ���̳Ŀ� ���� �� ������ �̷��� ������ ����ü�� �������� �ٲ���� �ִ�.
        Dictionary<RecipeName, Dictionary<MaterialName, int>> RecipeDic = new Dictionary<RecipeName, Dictionary<MaterialName, int>>()
    {
        { RecipeName.axe, new Dictionary<MaterialName, int>(){ { MaterialName.Bush, 1}, { MaterialName.Wood, 2 }, { MaterialName.Rock, 1 } } }, // ���� ���չ�
        { RecipeName.pickaxe, new Dictionary<MaterialName, int>(){ { MaterialName.Bush, 1}, { MaterialName.Wood, 2 }, { MaterialName.Rock, 2 } } } // ��� ���չ�
    };

        bool IsMaterialEnough(RecipeName _recipe, Inventory _inven) // �÷��̾��� �κ��丮�� �ް�
        {
            int count = 0;
            if (RecipeDic.ContainsKey(_recipe))
            {
                foreach (var item in RecipeDic[_recipe])
                {
                    count = _inven.GetIsAbleCount((int)item.Key); // �κ��� ��� ���� �̻����� �����ϰ� �ִ��� Ȯ���ϴ� �Լ�
                    if (count < item.Value)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
                return false;
        }
    }
    
    void AfterRecipe()
    {

    }


    
}
