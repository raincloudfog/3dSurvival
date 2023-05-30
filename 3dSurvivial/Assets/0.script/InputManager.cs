using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

public class InputManager : SingletonMono<InputManager>
{

    Dictionary<KeyCode, Action> KeyActions = new Dictionary<KeyCode, Action>(); // 키코드값 안에 액션안에 함수가 있다

    Player player;

    protected override void Init()
    {
        
    }

    public void AddFunction(KeyCode _key, Action _action)
    {
        if(KeyActions.ContainsKey(_key))//만약 같은 키면
        {
            KeyActions[_key] = null;
            KeyActions[_key] = _action;
        }
        else
        {
            KeyActions.Add(_key, _action); // 없다면 키에 새로운 함수를 넣는다.
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) // A를 눌렀을경우
        {
            if(KeyActions.ContainsKey(KeyCode.A)) // 만약 딕셔너리에 A값이 들어가있을경우
            {
                KeyActions[KeyCode.A](); //A 실행 다른 함수또 한 같이 진행됨.
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
