using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas GameOverCanavas;

    private void Start()
    {
        GameOverCanavas.enabled = false;
    }

    public void HandleDeath()
    {
        GameOverCanavas.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
