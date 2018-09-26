﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class SpellMenu : MonoBehaviour {

    public List<MenuButton> buttons = new List<MenuButton>();
    private Vector2 MousePos;
    private Vector2 fromVector2M = new Vector2(0.5f, 1.0f);
    private Vector2 centerCircle = new Vector2(0.5f, 0.5f);
    private Vector2 toVector2M;

    public GameObject menu;
    public int menuItems;
    public int currentItem;

    private int oldMenuItem;

	// Use this for initialization
	void Start () {
        menuItems = buttons.Count;
        foreach(MenuButton button in buttons)
        {
            button.image.color = button.NormalColor;
        }
        currentItem = 0;
        oldMenuItem = 0;
	}
	
	// Update is called once per frame
	void Update () {
        GetCurrentMenuItem();
        if (Input.GetButtonDown("Fire2"))
        {

            GetComponentInParent<FirstPersonController>().m_MouseLook.SetCursorLock(false);
            menu.SetActive(true);
            
            

        }
        if (Input.GetButtonUp("Fire2"))
        {
            ButtonAction();
            GetComponentInParent<FirstPersonController>().m_MouseLook.SetCursorLock(true);
            menu.SetActive(false);
        }
	}

    public void GetCurrentMenuItem()
    {
        MousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        toVector2M = new Vector2(MousePos.x / Screen.width, MousePos.y / Screen.height);
        float angle = (Mathf.Atan2(fromVector2M.y - centerCircle.y, fromVector2M.x - centerCircle.x) - Mathf.Atan2(toVector2M.y - centerCircle.y, toVector2M.x - centerCircle.x)) * Mathf.Rad2Deg;

        if (angle < 0) angle += 360;

        currentItem = (int)(angle / (360 / menuItems));

        if (currentItem != oldMenuItem)
        {
            buttons[oldMenuItem].image.color = buttons[oldMenuItem].NormalColor;
            oldMenuItem = currentItem;
            buttons[currentItem].image.color = buttons[currentItem].HightlightedColor;
        }
    }
    public void ButtonAction()
    {
        if (currentItem == 0) Debug.Log("Pressed first button");
    }
}


[System.Serializable]
public class MenuButton
{
    public string name;
    public Image image;
    public Color NormalColor = Color.white;
    public Color HightlightedColor = Color.gray;

}