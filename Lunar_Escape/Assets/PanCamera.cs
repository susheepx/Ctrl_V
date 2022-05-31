using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanCamera : MonoBehaviour
{
    [SerializeField]
    private Camera panCam;
    private Vector3 panCamPosition;
    private float zoomSize = 5.8f;

    // Start is called before the first frame update
    void Start()
    {
        panCamPosition = new Vector3(17.07f, 121f, -10f);
        panCam.transform.position = panCamPosition;
        gameObject.SetActive(false);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StartCoroutine(panCamera());
    }
    IEnumerator panCamera() {
        if (panCamPosition.y < 160f )
        {
            panCamPosition.y += 0.25f;
            panCam.transform.position = panCamPosition;
            yield break;
        }
        yield return new WaitForSeconds(0.75f);
        if (zoomSize >= 2.35)
        {
            zoomSize -= 0.2f;
            panCam.orthographicSize = zoomSize;
        }

    }
}
