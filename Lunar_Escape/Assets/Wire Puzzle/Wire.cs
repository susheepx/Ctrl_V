using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public static int numOfConnected;
    public static int numOfCorrect;
    private bool isWireConnected = false;
    //15% of >:(  85% :D
    Vector3 startPoint;
    Vector3 startPosition;
    public GameObject Left, Right;
    public BoxCollider2D Collider;
    public SpriteRenderer wireEnd;
    private void Start() {
        startPoint = transform.parent.position;
        startPosition = transform.position;
    }

    //call start setup when popup opened
    public void startSetup() {
        startPoint = transform.parent.position;
        startPosition = transform.position;
    }
    //Erica, please delete the following function.  This was for beta testing.
    public void Activate(){
        Left.SetActive(true);
        Right.SetActive(true);
        Start();
    }
    
    private void OnMouseDrag() {
        isWireConnected = false;
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
                if (transform.parent.name.Equals(collider.transform.parent.name)) {
                    //finish step
                    collider.GetComponent<Wire>()?.Done();
                    Done();
                }
                isWireConnected = true;

                return;
            }
        }

        //update wire
        UpdateWire(newPosition);
        
    }

    private void Done() {
        Destroy(this);
        numOfCorrect ++;
        Debug.Log(numOfCorrect);
        checkWires();
        
    }
    
    private void OnMouseUp() {

        if(transform.parent.name.Equals(GetComponent<BoxCollider2D>().transform.parent.name) && isWireConnected){
            //the line below adds 90s to the google sheets.
            //timer += 90.0f
            // Left.SetActive(false);
            // Right.SetActive(false);
            UpdateWire(startPosition);
        }
        // reset wire position
        if (! isWireConnected) {
            UpdateWire(startPosition);
            numOfConnected --;
            return;
        }
        else
            numOfConnected ++;
    }

    void checkWires() {
        if (numOfCorrect == 8) {
            Debug.Log("good job!");
            return;
        }
        else
            Debug.Log("oops try again");
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
