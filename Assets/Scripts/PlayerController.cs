using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController singleton { get; private set; }

    public event OnChangeHp onChangeHp; 
    public delegate void OnChangeHp(int _hp);

    [SerializeField] int hp;
    private void Awake()
    {
        if(singleton==null)
        {
            singleton = this;
        }
    }
    void Start()
    {
        Invoke(nameof(FirstСharacteristics), .1f); // передать начальные хп и т.д. инвок т.к. uiManager не успел подписаться на сабытие в старте чтобы его принять
    }
    void FirstСharacteristics()
    {
        onChangeHp?.Invoke(hp);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Danger"))
        {
            hp--;
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
            onChangeHp?.Invoke(hp);
        }
    }

}
