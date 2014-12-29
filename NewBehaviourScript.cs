
using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Mouse Orbit with zoom")]
public class MyMousLook : MonoBehaviour {
	
	//Ссылка на отслеживаемый объект
	public Transform target;
	//коэффициенты скорости по осям X Y
	public float xSpeed = 12.0f;
	public float ySpeed = 12.0f;
	//Скорость скрола
	public float scrollSpeed = 10.0f;
	//Максимальное и минимальное расстояние до камеры
	public float zoomMin = 1.0f;
	public float zoomMax = 30.0f;
	//Текущее расстояние док камеры
	public float distance = 15;
	public float Ypos;
	// позиция камеры
	public Vector3 position;
	public static Vector3 positionCamera; //Для передачи в скрипт управления персом
	//Зажата ли правая кнопка
	public bool isActivated;
	//для отслеживания позиции курсора по осям
	float x = 0.0f;
	float y = 0.0f;
	
	//инициализация
	
	void Start () {
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;
		
		position = (transform.forward * distance) + target.position;
		transform.position = position;
		Ypos = transform.position.y;
		
		distance = ZoomLimit(distance, zoomMin, zoomMax);
		//Вычисляем позицию где должна быть камера
		position = -(transform.forward * distance) + target.position;
		Ypos = position.y;
		//Перемещаем камеру
		transform.position = position;
	}
	
	
	void Update () {
		positionCamera = transform.position;
	}
	
	// Выполняется после полного обновления сцены
	void LateUpdate () {
		if (Input.GetMouseButtonDown(1)) {
			isActivated = true;     
		}       
		if (Input.GetMouseButtonUp(1)) {
			isActivated = false;    
		}
		
		if (target && isActivated){
			x += Input.GetAxis("Mouse X") * xSpeed;
			y -= Input.GetAxis("Mouse Y") * ySpeed;
			
			//Движение мыши горизонтально - поворачиваемся по - х
			transform.RotateAround(target.position, transform.up, x);
			//При движении мыши вертикально по ворачиваемся по оси - Y
			transform.RotateAround(target.position, transform.right, y);
			
			//Выпримление камеры по горизонту
			transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y,0);
			transform.rotation = Quaternion.LookRotation(target.position - transform.position);
			Ypos = transform.position.y;
			
			x = 0;
			y = 0;  
		}else {
			//Проверяем поворот колесика и выполняем
			if (Input.GetAxis("Mouse ScrollWheel") != 0) {
				//Расстояние между камерой и персонажем
				distance = Vector3.Distance (transform.position, target.position);
				//Инфа о повороте колесика
				distance = ZoomLimit(distance - Input.GetAxis("Mouse ScrollWheel")*scrollSpeed, zoomMin, zoomMax);
				//Вычисляем позицию где должна быть камера
				position = -(transform.forward * distance) + target.position;
				Ypos = position.y;
				//Перемещаем камеру
				transform.position = position;
			}
		}
		//Подтягивание камеры за персонажем при движении
		float d2 = Vector3.Distance(transform.position, target.position);
		if (d2 != distance) {
			position = -(transform.forward * distance) + target.position;
			position.y = Ypos;
			transform.position = position;
		}
	}
	
	public static float ZoomLimit(float angle, float min, float max)
	{
		if (angle < min)
			angle = min;
		if (angle > max)
			angle = max;
		return Mathf.Clamp(angle, min, max);
	}
}
