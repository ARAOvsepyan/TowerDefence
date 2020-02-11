using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Класс Жизней игрока
/// </summary>
/// Служит для текстовой визуализации 
public class Lives : MonoBehaviour
{
    /// <summary>
    /// Визуализированное количество жизней
    /// </summary>
    public Text lives;

    /// <summary>
    /// Функция присвает визуализированному обьекту значение количества жизней
    /// </summary>
    /// Вызывается один раз за кадр. Это основное событие для прорисовки кадра.
    void Update()
    {
        lives.text = "LIVES: " + Stats.Lives.ToString();
    }
}
