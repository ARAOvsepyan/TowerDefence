using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// Класс Поле игры
/// </summary>
/// Класс хранящий информацию о башне расположенной на поле(если она есть), 
/// функции для постройки башни на данном поле и дальнейше ее улучшении или продажи
public class Node : MonoBehaviour
{
    /// <summary>
    /// Цветоваяя визулизация выбранного поля
    /// </summary>
    public Color pointColor;
    /// <summary>
    /// Цветовая визуализция при нехватке денег для постройки башни
    /// </summary>
    public Color NotEnoughMoney;
    /// <summary>
    /// Позиция для постройки башни
    /// </summary>
    public Vector3 positionOffset;

    [Header("Option")]
    public GameObject tower;
    public TowerPrint towerPrint;
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;

    Build buildManager;
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = Build.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;


        if (tower != null)
        {
            buildManager.ChooseNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;

        BuildTower(buildManager.GetTowerToBuild());
    }
    /// <summary>
    /// Функция для постройки башни на поле игры
    /// </summary>
    /// <param name="tower">Башня для постройки</param>
    void BuildTower(TowerPrint tower)
    {
        if (Stats.Money < tower.cost)
        {
            return;
        }

        Stats.Money -= tower.cost;

        GameObject _tower = (GameObject)Instantiate(tower.prefab, GetBuildPosition(), Quaternion.identity);
        this.tower = _tower;

        towerPrint = tower;
    }
    /// <summary>
    /// Функция улучшения башни
    /// </summary>
    public void Upgrate()
    {
        if (Stats.Money < towerPrint.upgradeCost)
        { 
            return;
        }

        Stats.Money -= towerPrint.cost;

        Destroy(tower);

        GameObject _tower = (GameObject)Instantiate(towerPrint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        tower = _tower;

        isUpgraded = true;
    }
    /// <summary>
    /// Функция продажи башни
    /// </summary>
    public void SellTower()
    {
        Stats.Money += towerPrint.GetSellCost();

        Destroy(tower);
        towerPrint = null;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Stats.Money >= towerPrint.cost)
        {
            rend.material.color = pointColor;
        } else
        {
            rend.material.color = NotEnoughMoney;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}