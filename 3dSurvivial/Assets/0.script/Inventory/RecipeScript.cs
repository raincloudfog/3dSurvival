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
    /// 사용하기전 레시피
    /// </summary>
    void Before()
    {
        // 재료가 충분한지 여부를 검색을 어디서 하게 할 것이냐에 따라 이 구조도 이렇게 쓰던지 구조체로 쓰던지로 바뀔수도 있다.
        Dictionary<RecipeName, Dictionary<MaterialName, int>> RecipeDic = new Dictionary<RecipeName, Dictionary<MaterialName, int>>()
    {
        { RecipeName.axe, new Dictionary<MaterialName, int>(){ { MaterialName.Bush, 1}, { MaterialName.Wood, 2 }, { MaterialName.Rock, 1 } } }, // 도끼 조합법
        { RecipeName.pickaxe, new Dictionary<MaterialName, int>(){ { MaterialName.Bush, 1}, { MaterialName.Wood, 2 }, { MaterialName.Rock, 2 } } } // 곡괭이 조합법
    };

        bool IsMaterialEnough(RecipeName _recipe, Inventory _inven) // 플레이어의 인벤토리를 받고
        {
            int count = 0;
            if (RecipeDic.ContainsKey(_recipe))
            {
                foreach (var item in RecipeDic[_recipe])
                {
                    count = _inven.GetIsAbleCount((int)item.Key); // 인벤에 재료 개수 이상으로 소유하고 있는지 확인하는 함수
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
