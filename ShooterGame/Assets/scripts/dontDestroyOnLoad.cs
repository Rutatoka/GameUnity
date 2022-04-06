//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class dontDestroyOnLoad : MonoBehaviour
//{
//    public static dontDestroyOnLoad Instance;

//    void Awake()
//    {
//        this.InstantiateController();
//    }

//    private void InstantiateController()
//    {
//        if (Instance == null)
//        {
//            Instance = this;
//            DontDestroyOnLoad(this);
//        }
//        else if (this != Instance)
//        {
//            Destroy(this.gameObject);
//        }
//    }
//}
