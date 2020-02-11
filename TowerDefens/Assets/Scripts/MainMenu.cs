using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Класс Главново меню
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Кнопка для запуска игры
    /// </summary>
    public void Play()
    {
        SceneManager.LoadScene("1Lvl");
    }

    /// <summary>
    /// Кнопка для выхода из игры
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
