using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAnim : MonoBehaviour
{
    public Animator anim;
    private string INVENTORYANIM = "Slots Extended";
    // Update is called once per frame
    private void Start() {
        anim.SetBool(INVENTORYANIM, true);
    }
    public void ExpandInventory()
    {  
        if (gameObject.GetComponent<Animator>().GetBool (INVENTORYANIM) == true)
            //collapses inventory list
            anim.SetBool(INVENTORYANIM, false);
        else    
            //expands inventory list
            anim.SetBool(INVENTORYANIM, true);
    }
}
