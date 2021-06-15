using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] Text hp_txt;
   
    void Start()
    {
        PlayerController.singleton.onChangeHp += ChangeHp;

    }

    void ChangeHp(int currentHp) 
    {
        hp_txt.text = "hp:" + currentHp;
    }
}
