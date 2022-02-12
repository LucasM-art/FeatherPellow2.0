using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItens : MonoBehaviour
{
    [SerializeField] private Raycast ray;

    [Header("Itens to instantiate")]
    [SerializeField] private GameObject candle;
    [SerializeField] private Transform hand;

    public int lighters = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ray.isCandle)
            {
                Destroy(ray.raycastedObject);
                Instantiate(candle, hand.position, hand.rotation, hand);
            }

            if (ray.isLighter)
            {
                Destroy(ray.raycastedObject);
                lighters++;
            }
        }
    }
}
