using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// Класс Окончания игры при проигрыше
/// </summary>
public class GameOver : MonoBehaviour
{
    /// <summary>
    /// Визуализация количества пройденных волн
    /// </summary>
    public Text _countOfWaves;
    /// <summary>
    /// Функция присвает визуализированному обьекту значение волны
    /// </summary>
    /// Эта функция вызывается только после того, как объект будет включен.
    void OnEnable()
    {
        _countOfWaves.text = Stats.countOfWaves.ToString();
    }
    /// <summary>
    /// Кнопка для повторного прохождения уровня
    /// </summary>
    public void Restatr()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    /// <summary>
    /// Кнопка для выхода в главное меню
    /// </summary>
    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
