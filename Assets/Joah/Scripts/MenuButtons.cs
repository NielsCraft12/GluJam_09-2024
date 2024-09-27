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
        PlayerInfo.Instance.isPaused = false;
        Cursor.visible = true;
        SceneManager.LoadScene("level" + level);
    }

    public void Levels()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("Levels");
    }

    public void Credits()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("Credits");
    }

    public void Level1()
    {
        PlayerInfo.Instance.isPaused = false;
        PlayerInfo.Instance.level = 0;
        SceneManager.LoadScene("Level0");
    }

    public void Level2()
    {
        PlayerInfo.Instance.isPaused = false;
        PlayerInfo.Instance.level = 1;
        SceneManager.LoadScene("Level1");
    }

    public void Level3()
    {
        PlayerInfo.Instance.isPaused = false;
        PlayerInfo.Instance.level = 2;
        SceneManager.LoadScene("Level2");
    }

    public void MainMenu()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("Start");
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
        #elif (UNITY_WEBGL)
          Application.OpenURL("https://gohanblade.itch.io/you-only-have-one-box");
        #endif
    }
}
