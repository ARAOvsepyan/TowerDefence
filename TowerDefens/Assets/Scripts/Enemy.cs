using UnityEngine;
/*!
     \brief Класс "Враг"

      Данный класс хранит информацию о вражеских характеристиках, а так же функции для перемещения и нанесении урона            
 */
public class Enemy : MonoBehaviour {

    [Header("Enemy Stats")]
    /// Скорость передвежения
	public float speed = 10f;
    /// Количество жизней
    public int health = 200;
    /// Количество  денег за убийство врага
    public int value = 50;
    /// Обьект который будет перемещаться 
    private Transform target;
    /// Индекс точки перемещения
    private int wavepointIndex = 0;

    /*!
     * \brief Обьект получет значение первой точки перемещения
     * 
     * Start: Одна из функций событий, вызывается перед прорисовкой первого фрейма
     */
    void Start ()
	{
		target = Waypoints.points[0];
	}

    /*!
     * \brief Метод получения урона
     * 
     * "int damage" количество получаемого урона 
     */
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }
    /// Метод уничтожения обьекта
    void Die()
    {
        Stats.Money += value;

        Destroy(gameObject);
    }

    public void TestForDie()
    {
        Stats.Money += value;
    }
    /*!
     *  \brief Мeтод перемещения обьекта от одной точки к другой
     *  
     *  Update: Одна из функций событий, Update() вызывается один раз за кадр. Это основное событие для прорисовки кадра.
     */
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }
    /*!
     *  \brief Метод для получения следующей точки перемещения
     *  
     *  Обект будет уничтожен после получении последней точки пермещения и игроку нанесется урон
     */
    void GetNextWaypoint()
	{
		if (wavepointIndex >= Waypoints.points.Length - 1)
		{
            ReachTheEnd();
			Destroy(gameObject);
			return;
		}

		wavepointIndex++;
		target = Waypoints.points[wavepointIndex];
	}

    /*!
     *  \brief Метод для уменьшения жизней игрока 
     *  
     *  Жизни уменьшаются если враг доходит до конца
     */
    public void ReachTheEnd()
    {
        Stats.Lives -= 5;
    }
}