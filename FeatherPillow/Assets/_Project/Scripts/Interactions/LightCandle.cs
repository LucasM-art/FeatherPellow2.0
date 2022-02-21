using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCandle : MonoBehaviour
{
    private PickItens _item;
    [SerializeField] private GameObject fire;

    private void Start()
    {
        _item = GameObject.Find("Player").GetComponent<PickItens>();
    }

    private void Update()
    {
        if (_item.lighters > 0)
        {
            if (Input.GetMouseButtonDown(1))
            {
                fire.SetActive(true);
                _item.lighters--;
                _item.fireOn = true;
            }
        }
        else
        {
            print("You dont have any lighters");
        }
    }
}
