using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 20f;
    private PlayerController playerControllerScript;
    private float outY = -20;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (playerControllerScript.getGameOverStatut() != true)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if(this.transform.position.y < outY && this.gameObject.CompareTag("Obstacle"))
        {
            Destroy(this.gameObject);
        }

    }

}
