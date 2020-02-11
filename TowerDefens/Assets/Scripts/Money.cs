using System.Collections;
using UnityEngine.UI;
using UnityEngine;
/// <summary>
/// Класс Количества денег ирока
/// </summary>
/// Служит для текстовой визуализации 
public class Money : MonoBehaviour
{
    /// <summary>
    /// Визуализация количества денег
    /// </summary>
    public Text money;

    /// <summary>
    /// Функция присвает визуализированному обьекту количество денег
    /// </summary>
    /// Эта функция вызывается только после того, как объект будет включен.
    void Update()
    {
        money.text = "$" + Stats.Money.ToString();
    }
}
