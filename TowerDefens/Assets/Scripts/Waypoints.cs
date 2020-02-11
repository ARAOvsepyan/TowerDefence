using UnityEngine;
/// <summary>
/// Класс Траектории движения
/// </summary>
public class Waypoints : MonoBehaviour {
    /// <summary>
    /// Массив с координатами точек
    /// </summary>
	public static Transform[] points;
    /// <summary>
    /// Присваивает значения координат точек
    /// </summary>
    /// Эта функция всегда вызывается до начала любых функций, а также сразу после инициализации префаба.
	void Awake ()
	{
		points = new Transform[transform.childCount];
		for (int i = 0; i < points.Length; i++)
		{
			points[i] = transform.GetChild(i);
		}
	}

}