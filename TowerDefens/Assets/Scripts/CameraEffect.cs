using UnityEngine;
/// <summary>
/// Класс Перемещения камеры во время игры
/// </summary>
public class CameraEffect : MonoBehaviour
{
    /// <summary>
    /// Возможность двигать камеру
    /// </summary>
    private bool doMovement = true;
    /// <summary>
    /// Скорость перемещения
    /// </summary>
    public float speed = 30f;
    /// <summary>
    /// Длинна границы
    /// </summary>
    public float BorderLenght = 10f;

    public float minY = 10f;
    public float maxY = 80f;

    /// <summary>
    /// Функция осуществляет перемещение камеры
    /// </summary>
    /// Вызывается один раз за кадр. Это основное событие для прорисовки кадра.
    void Update()
    {
        if(GameManager._GameOver)
        {
            this.enabled = false;
            return;
        }

        if (!doMovement)
            return;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - BorderLenght)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= BorderLenght)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - BorderLenght)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= BorderLenght)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }

    }
}
