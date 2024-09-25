using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void PointerEnter()
    {
        transform.localScale = new Vector2(1.1f, 1.1f);
    }

    public void PointerExit()
    {
        transform.localScale = new Vector2(1f, 1f);
    }

    public void Restart()
    {
        int level = PlayerInfo.Instance.level;
        SceneManager.LoadScene("level" + level);
        PlayerInfo.Instance.isPaused = false;
    }

    public void Levels()
    {
        SceneManager.LoadScene("Levels");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level1");
        PlayerInfo.Instance.isPaused = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Start");
        PlayerInfo.Instance.isPaused = false;
    }

    public void Continue()
    {
        PlayerInfo.Instance.isPaused = false;
    }

    public void QuitGame()
    {
        #if (UNITY_EDITOR || DEVELOPMENT_BUILD)
              Debug.Log(this.name + " : " + this.GetType() + " : " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        #endif
        #if (UNITY_EDITOR)
             UnityEditor.EditorApplication.isPlaying = false;
        #elif (UNITY_STANDALONE)
         Application.Quit();
        #endif
    }
}
