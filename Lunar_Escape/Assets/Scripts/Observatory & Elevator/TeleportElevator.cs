using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportElevator : MonoBehaviour
{
    public GameObject astronaut;
    public GameObject enterElevator;
    public GameObject exitElevator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Collider2D>() == Astronaut.currentItem && ErikaLyingDown.isConscious == true) {
            Debug.Log(GetComponent<GameObject>());
            if (GetComponent<Collider2D>().gameObject == enterElevator)  {
                astronaut.transform.position = exitElevator.transform.position + new Vector3(1f, -4f, 0f);
            }
            else 
                astronaut.transform.position = enterElevator.transform.position + new Vector3(1f, -4f, 0f);
            Astronaut.currentItem = null;
        }
        
    }
}
