using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private float repeatX; //La coordonnée de la moitié de l'image qu'on va répéter
    private Vector3 startPos;


    void Start()
    {
        startPos = transform.position;
        repeatX = GetComponent<BoxCollider>().size.x / 2f;
    }

    void Update()
    {
        if(this.transform.position.x < startPos.x - repeatX) 
        {   
            this.transform.position = startPos;
        }
    }
}
