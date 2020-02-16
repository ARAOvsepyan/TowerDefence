using UnityEngine;
/// <summary>
/// Класс Башни
/// </summary>
/// Хранит информацию о характеристиках башни и функцию эффекта выстрла
public class Cannon : MonoBehaviour
{
    /// <summary>
    /// Позиция обьекта
    /// </summary>
    private Transform cannon;

    [Header("Attributes")]
    /// Радиус обзора башни
    public float Range = 15f;
    /// Скорость стрельбы
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Setup")]
    /// Метка
    public string enemy_tag = "Enemy";

    public Transform Tower;
    /// <summary>
    /// Скорость поворота башни
    /// </summary>
    public float turnSpeed = 10f;
    /// <summary>
    /// Обьект "Снаряд"
    /// </summary>
    public GameObject bulletPrefab;
    /// <summary>
    /// Точка выстрела снаряда
    /// </summary>
    public Transform firePoint;



    /// <summary>
    /// Функция вызывает метод UpdateTarget каждые 0.5 секунды
    /// </summary>
    /// Вызывается перед прорисовкой первого фрейма, только если сценарий определён.
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    /// <summary>
    /// Функция поиска ближайшего врага
    /// </summary>
    void UpdateTarget()
    {
        GameObject _enemy = null;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemy_tag);
        float _dis = Mathf.Pow(100, 100);
        foreach (GameObject enemy in enemies)
        {
            float _disToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (_disToEnemy < _dis)
            {
                _dis = _disToEnemy;
                _enemy = enemy;
            }
        }

        if (_dis <= Range && _enemy != null)
        {
            cannon = _enemy.transform;
        }
        else
        {
            cannon = null;
        }

    }

    /// <summary>
    /// Функция слежки за врагом
    /// </summary>
    /// Вызывается один раз за кадр. Это основное событие для прорисовки кадра.
    void Update()
    {
        if (cannon == null)
            return;

        /// Поворот башни за врагом
        Vector3 dir = cannon.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(Tower.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        Tower.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }
    /// <summary>
    /// Функция выстрела башни
    /// </summary>
    public void Shoot()
    {
        GameObject bulletFire = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletFire.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(cannon);
        }
    }
}