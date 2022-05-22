using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    Vector3 startPoint;
    Vector3 startPosition;
    public SpriteRenderer wireEnd;
    private void Start() {
        startPoint = transform.parent.position;
        startPosition = transform.position;
    }
    private void OnMouseDrag() {
        //mouse position to world point
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;
        
        //check for nearby connection
        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, 0.2f);
        foreach (Collider2D collider in colliders)
        {
            //make sure it is not my own collider
            if (collider.gameObject != gameObject) {

                //update wire position to connect to other wire
                UpdateWire(collider.transform.position);
                return;
            }
        }

        //update wire
        UpdateWire(newPosition);
        
        //update direction
        Vector3 direction = newPosition - startPoint;
        transform.right = direction * transform.lossyScale.x;
    }

    private void OnMouseUp() {
        // reset wire position
        UpdateWire(startPosition);
        Vector3 newPosition = startPosition;
        //update direction
        Vector3 direction = newPosition - startPoint;
        transform.right = direction * -transform.lossyScale.x;
    }

    void UpdateWire(Vector3 newPosition) {
        // update position
        transform.position = newPosition;
               

        

        //update scale
        float distance = Vector2.Distance(startPoint, newPosition);
        wireEnd.size = new Vector2(distance, wireEnd.size.y);


    }
}
