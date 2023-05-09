using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCar : MonoBehaviour
{
    public GameObject car;
    public float distance = 10f;
    public float height = 50f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    // Obtenha a posição do carro
    Vector3 carPosition = car.transform.position;
    
    // Defina a posição da câmera atrás do carro
    Vector3 cameraPosition = carPosition - car.transform.forward * distance;
    cameraPosition.y += height;
    
    // Atualize a posição da câmera
    transform.position = cameraPosition;
    
    // Faça a câmera olhar para o carro
    transform.LookAt(carPosition);
        
    }
}
