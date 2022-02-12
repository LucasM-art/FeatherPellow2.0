using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    [SerializeField] private Image crossHair;
    [SerializeField] private int rayLenght;
    [SerializeField] private LayerMask layerMask;

    [HideInInspector] public GameObject raycastedObject;

    public bool isCandle;
    public bool isLighter;

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, rayLenght, layerMask))
        {
            if (hit.collider.CompareTag("Candle"))
            {
                raycastedObject = hit.collider.gameObject;
                CrosshairActive();

                isCandle = true;
            }

            if (hit.collider.CompareTag("Lighter"))
            {
                raycastedObject = hit.collider.gameObject;
                CrosshairActive();

                isLighter = true;
            }
        }
        else
        {
            CrosshairNormal();

            isCandle = false;
            isLighter = false;
        }
    }

    private void CrosshairActive()
    {
        crossHair.color = Color.red;
    }

    private void CrosshairNormal()
    {
        crossHair.color = Color.white;
    }
}
