using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageIconsController : MonoBehaviour
{
    [SerializeField] GameObject Scrollbar;

    void Update()
    {
        transform.Translate(new Vector3(0, -5 * Input.GetAxis("Mouse ScrollWheel"), 0));
        if(transform.position.y < 0) transform.position = new Vector3(0, 0, 0);
        if(transform.position.y > 10) transform.position = new Vector3(0, 10, 0);
        Scrollbar.GetComponent<Scrollbar>().value = transform.position.y / 10f;
    }

    public void ScrollbarUpdate()
    {
        transform.position = new Vector3(0, 10f * Scrollbar.GetComponent<Scrollbar>().value, 0);
    }
}
