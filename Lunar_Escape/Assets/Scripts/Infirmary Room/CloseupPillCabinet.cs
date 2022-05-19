using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseupPillCabinet : MonoBehaviour
{
    //stay center of camera
    private Transform player;
    private Vector3 tempPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        tempPos = transform.position;
        tempPos.x = player.position.x;
        tempPos.y = player.position.y;
        
        transform.position = tempPos;
    }
}
