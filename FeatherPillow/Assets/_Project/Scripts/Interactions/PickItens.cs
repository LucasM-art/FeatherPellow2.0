using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItens : MonoBehaviour
{
    [SerializeField] private Raycast ray;

    [Header("Itens to instantiate")]
    [SerializeField] private GameObject candleNormal;
    [SerializeField] private GameObject candleLit;
    [SerializeField] private Transform hand;

    public int lighters = 0;
    public bool fireOn;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ray.isCandle)
            {
                Destroy(ray.raycastedObject);

                if (fireOn)
                {
                    Instantiate(candleLit, hand.position, hand.rotation, hand);
                }
                else
                {
                    Instantiate(candleNormal, hand.position, hand.rotation, hand);
                }
            }

            if (ray.isLighter)
            {
                Destroy(ray.raycastedObject);
                lighters++;
            }
        }
    }
}
