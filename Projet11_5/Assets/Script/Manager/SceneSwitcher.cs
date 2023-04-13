using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void ToGameScene()
    {
        SceneManager.LoadScene("Level");
    }

    public void ToMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}