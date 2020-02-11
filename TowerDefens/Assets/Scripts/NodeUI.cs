using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Класс Панели 
/// </summary>
/// Служит для улучшения башни или ее продажи
public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    private Node target;
    /// <summary>
    /// Текст на панели
    /// </summary>
    public Text upgradeText;
    /// <summary>
    /// Кнопка улучшения
    /// </summary>
    public Button upgradeButton;
    /// <summary>
    /// Текст на панели
    /// </summary>
    public Text sellText;
    
    /// <summary>
    /// Функция вызова панели для улучшения или продажи
    /// </summary>
    /// <param name="_target">Башня для улучшения</param>
    public void PlantTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeText.text = "$" + target.towerPrint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeText.text = "DONE!";
            upgradeButton.interactable = false;
        }

        sellText.text = "$" + target.towerPrint.GetSellCost();

        ui.SetActive(true);
    }
    /// <summary>
    /// Функция для снятия панели
    /// </summary>
    public void Hide()
    {
        ui.SetActive(false);
    }
    /// <summary>
    /// Кнопка для улучшения
    /// </summary>
    public void Upgrade()
    {
        target.Upgrate();
        Build.instance.NoChooseNode();
    }
    /// <summary>
    /// Кнопка для продажи
    /// </summary>
    public void Sell()
    {
        target.SellTower();
        Build.instance.NoChooseNode();
    }
}
