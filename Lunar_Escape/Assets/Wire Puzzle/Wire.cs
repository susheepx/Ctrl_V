using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public static bool isPuzzleOneSolved = false;
    public FadeScript fadeScript;
    public GameCanvasController prompts;
    public static int numOfConnected;
    public static int numOfCorrect;
    public Animator anim, fadeAnim;
    private bool isWireConnected = false;
    //15% of >:(  85% :D
    Vector3 startPoint;
    Vector3 startPosition;
    public GameObject Left, Right, wireGame;
    public BoxCollider2D Collider;
    public SpriteRenderer wireEnd;
    public List<Collider2D> wireColliders = new List<Collider2D>();
    public void Start() {
        if (gameObject != null) {
            startPoint = transform.parent.position;
            startPosition = transform.position;
        }
    }

    private void Update() {
        if (gameObject != null) {
            startPoint = transform.parent.position;
            startPosition = transform.position;
        }
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
            if (collider.gameObject != gameObject && collider.gameObject.transform.parent != gameObject.transform.parent && wireColliders.Contains(collider)) {

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
    
    //fade out during blackout
    public IEnumerator FadeOutIn() {
        Timer.timer += 120.0f;
        yield return new WaitForSeconds(0.03f);
        fadeAnim.SetTrigger("Start");
        yield return new WaitForSeconds(2f);
        fadeAnim.SetTrigger("End");
        prompts.openDialogueBox(3, prompts.ActI);
        UpdateWire(startPosition);
        wireGame.SetActive(false);
        BreakerWires.isWiresOpen = false; 
    }
    private void OnMouseUp() {

        if(transform.parent.name.Equals(GetComponent<BoxCollider2D>().transform.parent.name) && isWireConnected){
            //the line below adds 90s to the google sheets.
            //timer += 90.0f
            // Left.SetActive(false);
            // Right.SetActive(false);
            //call the fade out "blackout" and return to electrical room
            StartCoroutine(FadeOutIn());
            
            
            
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

    public Timer timer;
    void checkWires() {
        if (numOfCorrect == 4) {
            Debug.Log("good job!");
            wireGame.SetActive(false);
            Astronaut.canMove = true;
            anim.SetTrigger("ElectricalDoorOpen");
            prompts.openDialogueBox(4, prompts.ActI);
            Timer.hintCount = 4;
            timer.StopTimer();
            timer.StartTimer();
            isPuzzleOneSolved = true;
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
