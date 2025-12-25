using UnityEngine;
using UnityEngine.UI;

public class PausMenu : MonoBehaviour
{
    [Header("Sliders")]
    public Slider musicSlaider;
    public Slider saundsSlider;

    [Header("GameObgects")]
    public GameObject menu;
    public GameObject setings;

    [Header("Inputs")]
    public KeyCode escKey = KeyCode.Escape;

    public bool isEscape;

    private void Update()
    {
        if (Input.GetKeyDown(escKey))
        {
            if (!isEscape)
            {
                OpenMenu();
            }
            else
            {
                CloseMenu();
            }
        }
    }

    public void OpenSetings()
    {
        menu.SetActive(false);
        setings.SetActive(true);
    }
    public void CloseSetings()
    {
        setings.SetActive(false);
        menu.SetActive(true);
    }

    public void CloseMenu()
    {
        menu.SetActive(false);
        setings.SetActive(false);
        isEscape = false;
        Time.timeScale = 1f;
    }

    public void OpenMenu()
    {
        menu.SetActive(true);
        isEscape = true;
        Time.timeScale = 0f;
    }

    public void ExitFromGame()
    {
        Application.Quit();
    }
}
