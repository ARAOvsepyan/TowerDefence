using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Класс Окончания игры при победе
/// </summary>
public class Won : MonoBehaviour
{
    /// <summary>
    /// Кнопка перехода на новый уровень
    /// </summary>
    public void NextLevel()
    {
        Debug.Log("Go to next level");
    }
    /// <summary>
    /// Кнопка перехода в главное меню
    /// </summary>
    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
