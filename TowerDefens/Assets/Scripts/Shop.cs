using UnityEngine;
/// <summary>
/// Класс Магазина
/// </summary>
/// Хранит информацию о возможных башнях для покупки
public class Shop : MonoBehaviour
{
    /// <summary>
    /// Башня 1
    /// </summary>
    public TowerPrint Cannon;
    /// <summary>
    /// Башня 2
    /// </summary>
    public TowerPrint Mortar;


    Build buildManager;

    void Start()
    {
        buildManager = Build.instance;
    }
    /// <summary>
    /// Функция выбора Башни 1
    /// </summary>
    public void SelectCannon()
    {
        buildManager.ChooseTowerToBuild(Cannon);
    }
    /// <summary>
    /// Функция выбора Башни 2
    /// </summary>
    public void SelectMortar()
    {
        buildManager.ChooseTowerToBuild(Mortar);
    }

}