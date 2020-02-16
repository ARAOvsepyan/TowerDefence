using UnityEngine;
/// <summary>
/// Класс Диспетчер игрового процесса
/// </summary>
/// Хранит инфомацию о выйгрыше и проигрыше
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Окончание игры при проигрыше
    /// </summary>
    public GameObject gameOver;
    public static bool _GameOver;
    /// <summary>
    /// Победа в ире
    /// </summary>
    public GameObject won;
    public static bool _Won;
    /// <summary>
    /// Функция начала игры
    /// </summary>
    /// Вызывается перед прорисовкой первого фрейма, только если сценарий определён.
    void Start()
    {
        _Won = false;
        _GameOver = false;
    }

    /// <summary>
    /// Функция проверки на окончание игры
    /// </summary>
    /// Вызывается один раз за кадр. Это основное событие для прорисовки кадра.
    void Update()
    {
        if (_GameOver)
        {
            return;
        }
        if (Input.GetKeyDown("e"))
        {
            GameOver();
        }
        if (Stats.Lives <= 0)
        {
            GameOver();
        }
        if (Input.GetKeyDown("q"))
        {
            Won();
        }
    }
    /// <summary>
    /// Функция окончания игры при проигрыше
    /// </summary>
    public void GameOver()
    {
        _GameOver = true;
        gameOver.SetActive(true);
    }
    /// <summary>
    /// Функция окончания игры при выйгрыше
    /// </summary>
    void Won()
    {
        _Won = true;
        won.SetActive(true);
    }
}
