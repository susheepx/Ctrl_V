using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public IEnumerator waitFadeTime() {
        yield return new WaitForSeconds(0.3f);
        anim.SetTrigger("Start");
    }


}
