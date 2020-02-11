using UnityEngine;
/*!
 *  \brief Класс Снаряда
 *  
 *  Данный класс хранит информацию о характеристиках снаряда, а так же функции для пермещения снаряда к цели и нанесению урона
 */
public class Bullet : MonoBehaviour
{   
    /// <summary>
    /// Позоция обьекта
    /// </summary>
    private Transform target;
    /// Скорость полета снаряда
    public float speed = 70f;
    /// Радиус поражения
    public float burstingRadius = 0f;
    /// Количество нанесенного урона при попадании
    public int damage = 50;
    /// Эффект попадания снаряда в цель
    public GameObject Effect;
    /// <summary>
    /// Функция полета снаряда до цели
    /// </summary>
    /// <param name="_target">Цель снаряда</param>
    public void Seek(Transform _target)
    {
        target = _target;
    }
    /// <summary>
    /// Функция проприсовки полета снаряда до врага
    /// </summary>
    /// Вызывается один раз за кадр. Это основное событие для прорисовки кадра.
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distanceThisFrame)
        {
            StrikeTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);

    }
    /// <summary>
    /// Функция попадания в цель
    /// </summary>
    void StrikeTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(Effect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

        if (burstingRadius > 0f)
        {
            Bursting();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }
    /// <summary>
    /// Функция взрыва снаряда
    /// </summary>
    void Bursting()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, burstingRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    /// <summary>
    /// Функция нанесения урона
    /// </summary>
    /// <param name="enemy">Враг</param>
    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }

}