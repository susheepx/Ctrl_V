using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPrompt : MonoBehaviour
{
    public Transform astronaut;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }


    private void FixedUpdate() {
        transform.position = astronaut.position + new Vector3(0, 2.25f, 0f);
    }
}
