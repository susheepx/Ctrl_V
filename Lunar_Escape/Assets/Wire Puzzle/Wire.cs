using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public int numOfConnected;
    private bool isWireConnected = false;
    
    Vector3 startPoint;
    Vector3 startPosition;
    public GameObject lightOn;
    public SpriteRenderer wireEnd;
    private void Start() {
        startPoint = transform.parent.position;
        startPosition = transform.position;
    }
    private void OnMouseDrag() {
        isWireConnected = false;
        lightOn.SetActive(false);
        //mouse position to world point
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;
        
        //check for nearby connection
        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, 0.2f);
        foreach (Collider2D collider in colliders)
        {
            //make sure it is not my own collider
            if (collider.gameObject != gameObject && collider.gameObject.transform.parent != gameObject.transform.parent) {

                //update wire position to connect to other wire
                UpdateWire(collider.transform.position);

                // check if the wire connection is correct
                //if (transform.parent.name.Equals(collider.transform.parent.name)) {
                    //finish step
                collider.GetComponent<Wire>()?.Done();
                Done();
                //}
                return;
            }
        }

        //update wire
        UpdateWire(newPosition);
        
    }

    private void Done() {
        //turn on light
        lightOn.SetActive(true);
        isWireConnected = true;
        
    }
    
    private void OnMouseUp() {
        
        // reset wire position
        if (! isWireConnected) {
            UpdateWire(startPosition);
            CheckWires();
        }
    
    void CheckWires() {
        if (isWireConnected) {
            numOfConnected = numOfConnected + 1;
        }
    }
    
    }

    void UpdateWire(Vector3 newPosition) {
        // update position
        transform.position = newPosition;
               
        
        Vector3 direction = newPosition - startPoint;
        transform.right = direction * transform.lossyScale.x;
        

        //update scale
        float distance = Vector2.Distance(startPoint, newPosition);
        wireEnd.size = new Vector2(distance, wireEnd.size.y);


    }
}
