using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoseGame : MonoBehaviour
{
    public TextMeshProUGUI loseText;
    private bool hasCrashed = false;

    void Start()
    {
        loseText.enabled = false;
    }

    void OnCollisionEnter(Collision other)
    {        
        if (other.gameObject.CompareTag("RallyCar"))
        {
            Debug.Log("Teste");
            hasCrashed = true;
            loseText.enabled = true;
            loseText.text = "Lose";
        }
    }

    void Update()
    {
        if (hasCrashed)
        {                    
            GameObject.FindGameObjectWithTag("RallyCar").GetComponent<VehicleControl>().StopCar();
        }
    }
}
