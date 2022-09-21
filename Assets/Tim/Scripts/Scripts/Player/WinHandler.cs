using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinHandler : MonoBehaviour
{
    [SerializeField] Canvas WinnerCanavas;

    private void Start()
    {
        WinnerCanavas.enabled = false;
    }

    public void Update()
    {
        if (EggPickup.amountOfEggs == 5)
        {
            HandleWin();
        }
    }

    public void HandleWin()
    {
        WinnerCanavas.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
