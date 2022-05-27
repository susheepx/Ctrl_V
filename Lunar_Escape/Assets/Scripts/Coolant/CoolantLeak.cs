using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class CoolantLeak : MonoBehaviour
{
    public UI_Inventory inventory;
    public TextMeshProUGUI controlText;
    public GameObject controlPrompt;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update() {
        if (Astronaut.interact && GetComponent<Collider2D>() == Astronaut.currentItem) 
            controlText.text = "- Use Adhesive -";

    }

    public void fixCoolant() {
        
        if (Astronaut.interact && GetComponent<Collider2D>() == Astronaut.currentItem && EventSystem.current.currentSelectedGameObject.name == "adhesiveIcon") 
        {
            controlPrompt.SetActive(false);
            inventory.testList();
            anim.SetTrigger("Fixed");
            StartCoroutine(fadeEndgame());
        }
    }

    IEnumerator fadeEndgame() {
        yield return new WaitForSeconds(1);
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(1.25f);
        SceneManager.LoadScene(sceneBuildIndex:3);
    }
            
    
}
