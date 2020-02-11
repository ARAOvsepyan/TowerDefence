using System.Collections;
using UnityEngine;
/// <summary>
/// Класс Характеристик игрока
/// </summary>
public class Stats : MonoBehaviour
{
    /// <summary>
    /// Количество денег, жизнй, пройденых волн
    /// </summary>
    [Header("Stats")]
    public static int Money;
    public static int Lives;
    public static int countOfWaves;
    
    /// <summary>
    /// Начальное количество денег
    /// </summary>
    public int basicMoney = 200;
    /// <summary>
    /// Начальное количество жизней
    /// </summary>
    public int basicLives = 20;

    /// <summary>
    /// Функция присваивает начальные значения денег и жизней игрока, обнуляет колчиство волн
    /// </summary>
    /// Вызывается перед прорисовкой первого фрейма, только если сценарий определён.
    void Start()
    {
        Money = basicMoney;
        Lives = basicLives;

        countOfWaves = 0;
    }

}
