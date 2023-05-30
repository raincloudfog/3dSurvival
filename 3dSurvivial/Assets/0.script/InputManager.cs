using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

public class InputManager : SingletonMono<InputManager>
{

    Dictionary<KeyCode, Action> KeyActions = new Dictionary<KeyCode, Action>(); // Ű�ڵ尪 �ȿ� �׼Ǿȿ� �Լ��� �ִ�

    Player player;

    protected override void Init()
    {
        
    }

    public void AddFunction(KeyCode _key, Action _action)
    {
        if(KeyActions.ContainsKey(_key))//���� ���� Ű��
        {
            KeyActions[_key] = null;
            KeyActions[_key] = _action;
        }
        else
        {
            KeyActions.Add(_key, _action); // ���ٸ� Ű�� ���ο� �Լ��� �ִ´�.
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) // A�� ���������
        {
            if(KeyActions.ContainsKey(KeyCode.A)) // ���� ��ųʸ��� A���� ���������
            {
                KeyActions[KeyCode.A](); //A ���� �ٸ� �Լ��� �� ���� �����.
            }
        }
        else if(Input.GetKeyDown(KeyCode.X))
        {
            if(KeyActions.ContainsKey(KeyCode.X))
            {
                KeyActions[KeyCode.X]();
            }
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            if (KeyActions.ContainsKey(KeyCode.Space))
            {
                KeyActions[KeyCode.Space]();
            }
        }

        else if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(KeyActions.ContainsKey(KeyCode.LeftShift))
            {
                KeyActions[KeyCode.LeftShift]();
            }
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (KeyActions.ContainsKey(KeyCode.LeftShift))
            {
                KeyActions[KeyCode.LeftShift]();
            }
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            if (KeyActions.ContainsKey(KeyCode.E))
            {
                KeyActions[KeyCode.E]();
            }
        }



    }
}
