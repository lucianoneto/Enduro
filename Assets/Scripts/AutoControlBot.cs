using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoControlBot : MonoBehaviour
{
    public float MovementSpeed = 6f;
    public float TurningSpeed = 1f;
    public string WaypointTag;
    public float WpCountdown = 5f;

    bool IsMoving;
    Vector3 dist;
    bool WpReached;
    GameObject StartingPoint;
    string TargetWpToGo;
    int CurrentWpNumber;
    Rigidbody rb;
    float CurrentWpCountdown;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("PatrolNow", 1);
        IsMoving = true;
        
    }

    public void PatrolNow()
    {
        rb = GetComponent<Rigidbody>();
        StartingPoint = FindClosestWaypoint();
        TargetWpToGo = StartingPoint.gameObject.name;
        CurrentWpNumber = int.Parse(TargetWpToGo.Split(char.Parse("-"))[1]);
        IsMoving = true;        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsMoving)
        {
            GameObject WpToGo = GameObject.Find(WaypointTag + "-" + CurrentWpNumber);
            Vector3 lookPos = WpToGo.transform.position - transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * TurningSpeed);
            transform.position += transform.forward * Time.deltaTime * MovementSpeed;
           
        }
    }

    //Function for finding closest waypoint
    public GameObject FindClosestWaypoint()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(WaypointTag);   
        Debug.Log(WaypointTag);     
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        Debug.Log("Closest found: " + closest.gameObject.name);
        return closest;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == WaypointTag && !WpReached)
        {
            WpReached = true;            
            if (GameObject.Find(WaypointTag + "-" + (CurrentWpNumber + 1)) != null)
            {
                CurrentWpNumber += 1;                
            }
            else
                CurrentWpNumber = 0;
        }      
    }

    private void OnTriggerExit(Collider other)
    {        
        if (other.tag == WaypointTag && WpReached)
        {
            WpReached = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "RallyCar")
        {
            IsMoving = false;
        }
    }
}
