using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject skinWardrobeMenu;
    [SerializeField] private GameObject levelsMenu;
    [SerializeField] private GameObject shopMenu;

    public void TestChangeScene()
    {
        SceneManager.LoadScene("TestScene");
    }

    private void Start()
    {
        Activate_MainMenu();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Activate_MainMenu()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        skinWardrobeMenu.SetActive(false);
        levelsMenu.SetActive(false);
        shopMenu.SetActive(false);
    }

    public void Activate_OptionsMenu(bool state)
    {
        mainMenu.SetActive(state);
        optionsMenu.SetActive(!state);
    }

    public void Activate_SkinWardrobeMenu(bool state)
    {
        mainMenu.SetActive(state);
        skinWardrobeMenu.SetActive(!state);
    }

    public void Activate_LevelsMenu(bool state)
    {
        mainMenu.SetActive(state);
        levelsMenu.SetActive(!state);
    }

    public void Activate_ShopMenu(bool state)
    {
        mainMenu.SetActive(state);
        shopMenu.SetActive(!state);
    }

    public void Play() => SceneManager.LoadScene(1);

    public void Quit() => Application.Quit();
}