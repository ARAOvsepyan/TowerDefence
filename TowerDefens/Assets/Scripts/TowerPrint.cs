using UnityEngine;
/// <summary>
/// Класс Чертежи башен
/// </summary>
/// Служит для хранения моделей башен
[System.Serializable]
public class TowerPrint
{
    /// <summary>
    /// Модель башни
    /// </summary>
    public GameObject prefab;
    /// <summary>
    /// Цена башни
    /// </summary>
    public int cost;
    /// <summary>
    /// Модель улучшенной башни
    /// </summary>
    public GameObject upgradedPrefab;
    /// <summary>
    /// Цена улучшенной башни
    /// </summary>
    public int upgradeCost;
    /// <summary>
    /// Функция выбора количества полученых денег с продажи башни
    /// </summary>
    /// <returns>Количество полученных денег</returns>
    public int GetSellCost()
    {
        return (cost / 2);
    }
}
