using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void ToGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void ToMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
