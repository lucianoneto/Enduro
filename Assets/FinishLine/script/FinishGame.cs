using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinishGame : MonoBehaviour
{
    private bool hasCrossedFinishLine = false;

    public TextMeshProUGUI winText;

    void Start()
    {
        winText.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RallyCar"))
        {
            Debug.Log("Chegou!!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("RallyCar"))
        {
            hasCrossedFinishLine = true;
            Debug.Log("Cruzou a linha de chegada!");
            winText.enabled = true; // Mostra o texto
            winText.text = "Win"; // Altera o texto para "Win"
        }
    }

    void Update()
    {
        if (hasCrossedFinishLine && !GetComponent<Collider>().bounds.Contains(GameObject.FindGameObjectWithTag("RallyCar").transform.position))
        {
            Debug.Log("Parando o carro...");
            GameObject.FindGameObjectWithTag("RallyCar").GetComponent<VehicleControl>().StopCar();
        }
    }
}
