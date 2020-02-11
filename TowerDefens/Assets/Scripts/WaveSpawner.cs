using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// Класс создания игровых волн
/// </summary>
public class WaveSpawner : MonoBehaviour
{   
    /// <summary>
    /// Координаты врага
    /// </summary>
    public Transform enemyP;
    /// <summary>
    /// Координаты точки появления врагов
    /// </summary>
    public Transform spawnPoint;
    /// <summary>
    /// Время между волнами
    /// </summary>
    public float timeBetweenWaves = 4.5f;
    /// <summary>
    /// Обратный отсчет перед началом игры
    /// </summary>
    private float countdown = 3.5f;
    /// <summary>
    /// Цекстовая визуализация обратного отсчета
    /// </summary>
    public Text waveCountdownText;
    /// <summary>
    /// Номер волны
    /// </summary>
    private int waveIndex = 0;
    /// <summary>
    /// Создает новую волну каждые 3.5 секунды
    /// </summary>
    /// Вызывается один раз за кадр. Это основное событие для прорисовки кадра.
    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }
    /// <summary>
    /// Создание новых волн
    /// </summary>
    /// <returns>Создает волну с ожиданием в 0.5 сек</returns>
    IEnumerator SpawnWave()
    {
        waveIndex++;
        Stats.countOfWaves++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }
    /// <summary>
    /// Создание врага
    /// </summary>
    public void SpawnEnemy()
    {
        Instantiate(enemyP, spawnPoint.position, spawnPoint.rotation);
    }

}