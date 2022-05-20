using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infirmaryNote : MonoBehaviour
{

    public GameObject infirmaryCode;
    private bool isPoemOpened = false;
    private SpriteRenderer currentSprite;
    // Start is called before the first frame update
    private void Start() {
        currentSprite = gameObject.GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && GetComponent<Collider2D>() == Astronaut.currentItem) {
                if (isPoemOpened == false) {
                    infirmaryCode.SetActive(true);
                    isPoemOpened = true;
                }
                else {
                    infirmaryCode.SetActive(false);
                    isPoemOpened = false;
                }

            }
        }
    
}
