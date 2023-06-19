using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Singleton
{
    public class SingletonMono<T> : MonoBehaviour where T : SingletonMono<T>
    {
        protected static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    var obj = FindObjectOfType<T>(); //���̾��Ű�� �̸� ������ ���ӸŴ��� ��ü�� �̹� ������.. �¸� ã�ƶ�
                    if (obj != null)
                    {
                        _instance = obj;
                        _instance.Init();//
                        DontDestroyOnLoad(obj.gameObject);
                    }
                    else
                    {
                        var newObj = new GameObject(typeof(T).Name, typeof(T));
                        _instance = newObj.GetComponent<T>();
                        if (_instance == null)
                        {
                            _instance = newObj.AddComponent<T>();
                        }
                        _instance.Init();
                        DontDestroyOnLoad(newObj);
                    }
                }
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }

        protected virtual void Init()
        {
        }
        public virtual void Release()
        {
        }
        public virtual void Regist() { }
    }

    public class Singleton<T> : MonoBehaviour where T : Singleton<T>, new()
    {
        protected static T _instance = null;

        public static T Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;
                _instance = new T(); ;
                _instance.Init(); // �Ŵ��� �ʱ�ȭ��
                return _instance;
            }
        }

        protected virtual void Init()
        {

        }

    }
}