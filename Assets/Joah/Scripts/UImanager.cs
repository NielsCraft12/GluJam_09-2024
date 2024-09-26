using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField] List<GameObject> hearts;
    [SerializeField] GameObject escMenu;

    private void Start()
    {
        PlayerInfo.Instance.DamagePoints = 0;
        PlayerInfo.Instance.isPaused = false;
    }

    private void Update()
    {
        if(PlayerInfo.Instance.DamagePoints > 0)
        {
            hearts[PlayerInfo.Instance.DamagePoints - 1].SetActive(false);
        }

        if(PlayerInfo.Instance.DamagePoints >= 3)
        {
            SceneManager.LoadScene("GameOver");
        }

        if(PlayerInfo.Instance.isPaused)
        {
            escMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            escMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
