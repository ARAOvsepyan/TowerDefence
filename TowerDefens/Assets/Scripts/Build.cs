using UnityEngine;
/*!
 *  \brief Класс Постройки здания
 *  
 *  Данный класс хранит информацию о возможных зданиях для постройки, а так же функции выбора поля игры для постройки башни 
 */
public class Build : MonoBehaviour
{
    /// Реализации паттерна Singleton
    public static Build instance;   
    /// Обьект башни 1
    public GameObject CannonPrefab;
    /// Обьект башни 2
    public GameObject MortarPrefab;
    /// <summary>
    /// Чертеж башни
    /// </summary>
    private TowerPrint towerToBuild;
    /// <summary>
    /// Выбранное игровое поле 
    /// </summary>
    private Node selectedNode;
    /// Панель для улучшения или продажи башен
    public NodeUI nodeUI;
    /// Функция для проверки возмжности построения башни
    public bool CanBuild { get { return towerToBuild != null; } }
    /// <summary>
    /// Присваивает паттерн Singleton'a
    /// </summary>
    /// Эта функция всегда вызывается до начала любых функций, а также сразу после инициализации префаба.
    void Awake()
    {
        instance = this;
    }
    /*!
     *  \brief Функция выбора поля игры для постройки башни
     *  
     *  Если башня уже стоит появляется окно для улучшения или продажи 
     */
    public void ChooseNode(Node node)
    {
        if (selectedNode == node)
        {
            NoChooseNode();
            return;
        }
        selectedNode = node;
        towerToBuild = null;
        nodeUI.PlantTarget(node);
    }
    /// Функция отмены выбора поля игры 
    public void NoChooseNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
    /*!
    *   Функция выбора башни для постройки
    */
    public void ChooseTowerToBuild(TowerPrint tower)
    {
        towerToBuild = tower;

        NoChooseNode();
    }
    /*!
    *   Функция возвращает тип выбранной башни
    */
    public TowerPrint GetTowerToBuild()
    {
        return towerToBuild;
    }

}
