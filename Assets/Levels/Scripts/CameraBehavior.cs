using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] private GameObject ObjectToFollow;
    private Transform CurrentPos;
    [SerializeField] private double DistanceApart;

    void Awake()
    { 
        CurrentPos = GetComponent<Transform>();

        Debug.Log(CurrentPos);
    }

    void Update()
    {
        float TimeLag = (float)DistanceApart * Time.deltaTime; 
        CurrentPos.position = Vector3.MoveTowards(CurrentPos.position,new Vector3(ObjectToFollow.transform.position.x - Input.GetAxis("Horizontal"),ObjectToFollow.transform.position.y + 3,-0.95f),TimeLag);

    }
}
