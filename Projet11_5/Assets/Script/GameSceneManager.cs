using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
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
