using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Transform myTransform;               
    Vector3 targetPosition;        // точку куда нужно идти
    float destinationDistance;          // дистанция между нами и точкой куда идти
    [SerializeField] Camera _camera; //главная камера, от нее будем пускать луч

    float moveSpeed;

    void Start()
    {
        myTransform = transform;
        targetPosition = myTransform.position;         // в начале он стоит на месте, значит и цель это наша позиция
    }

    void Update()
    {
        move();
    }

    void move()
    {
        destinationDistance = Vector3.Distance(myTransform.position, targetPosition); // узнаем дистанцию от нас до точку куда нужно идти

        if (destinationDistance < .5f) //   если расстояния меньше 0.5 то останавливаемся
        {
            moveSpeed = 0;
        }
        else if (destinationDistance > .5f)// иначе ставим скорость перемещения стандартной.
        {
            moveSpeed = 10;
        }
        // Движение, если игрок нажал  кнопку мыши
        if (Input.GetMouseButtonDown(0))
        {
            Plane playerPlane = new Plane(Vector3.up, myTransform.position);
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            float hitdist = 0.0f;

            if (playerPlane.Raycast(ray, out hitdist))
            {
                Vector3 targetPoint = ray.GetPoint(hitdist);
                targetPosition = ray.GetPoint(hitdist);
                Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
                myTransform.rotation = targetRotation;
            }
        }
        // Предотвращает запуск кода, если он не требуется.
        if (destinationDistance > .5f)
        {
            myTransform.position = Vector3.MoveTowards(myTransform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
}

