using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenu : MonoBehaviour
{
    [SerializeField] private PickItens item;
    [SerializeField] private PauseMenu pause;
    [SerializeField] private GameObject gameHud;

    [Header("Menu Variables")]
    [SerializeField] private GameObject[] menus;
    [SerializeField] private GameObject nextButtom;
    [SerializeField] private GameObject backButtom;
    [SerializeField] private GameObject exitButtom;

    [HideInInspector] public bool onMenu;
    private int _currentMenu;

    [Header("Inventory Slots")]
    [SerializeField] private GameObject[] slots;

    private void Start()
    {
        foreach (GameObject menu in menus)
        {
            menu.SetActive(false);
        }
        onMenu = false;
        _currentMenu = 0;

        nextButtom.SetActive(false);
        backButtom.SetActive(false);
        exitButtom.SetActive(false);

        foreach (GameObject slot in slots)
        {
            slot.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!onMenu)
            {
                gameHud.SetActive(false);
                pause.isPaused = true;

                onMenu = true;
                menus[_currentMenu].SetActive(true);
                nextButtom.SetActive(true);
                backButtom.SetActive(true);
                exitButtom.SetActive(true);

                Time.timeScale = 0;

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else if (onMenu)
            {
                Back();
            }
        }

        if (item.lighters > 0)
        {
            slots[0].SetActive(true);
        }
        else
        {
            slots[0].SetActive(false);
        }
    }

    public void ChangePageForward()
    {
        if(_currentMenu >= 3)
        {
            _currentMenu = 3;
            menus[3].SetActive(true);
        }
        else
        {
            menus[_currentMenu].SetActive(false);
            _currentMenu++;
            menus[_currentMenu].SetActive(true);
        }
    }

    public void ChangePageBackward()
    {
        if(_currentMenu <= 0)
        {
            _currentMenu = 0;
            menus[0].SetActive(true);
        }
        else
        {
            menus[_currentMenu].SetActive(false);
            _currentMenu--;
            menus[_currentMenu].SetActive(true);
        }
    }

    public void Back()
    {
        gameHud.SetActive(true);
        pause.isPaused = false;

        onMenu = false;
        menus[_currentMenu].SetActive(false);
        nextButtom.SetActive(false);
        backButtom.SetActive(false);
        exitButtom.SetActive(false);

        Time.timeScale = 1;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
