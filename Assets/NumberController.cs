using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberController : MonoBehaviour
{

    bool snap = false;
    float[] color = { 1, 1, 1 };
    [SerializeField] float[] ClearColor;

    public void Chase()
    {
        if (!this.snap)
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10f));
            GetComponent<Transform>().position = mouseWorldPosition;
        }
        GetComponent<BoxCollider2D>().size = new Vector2(0.01f, 0.01f);
        GetComponent<SpriteRenderer>().sortingOrder = 2;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Box" && collision.GetComponent<BoxController>().Number == "0")
        {
            GetComponent<Transform>().position = collision.transform.position;
            this.snap = true;
            collision.GetComponent<BoxController>().Number = this.gameObject.name;
            GetComponent<AudioSource>().Play();
        }
    }

    public void Exit()
    {
        this.snap = false;
        GetComponent<BoxCollider2D>().size = new Vector2(1f, 1f);
        GetComponent<SpriteRenderer>().sortingOrder = 1;
    }

    public void Clear()
    {
        InvokeRepeating("Color", 0, 0.05f);
    }

    void Color()
    {
        color[0] -= (1 - ClearColor[0]) / 50;
        color[1] -= (1 - ClearColor[1]) / 50;
        color[2] -= (1 - ClearColor[2]) / 50;
        this.GetComponent<SpriteRenderer>().color = new Color(color[0], color[1], color[2]);
        if (this.GetComponent<SpriteRenderer>().color == new Color(ClearColor[0], ClearColor[1], ClearColor[2])) CancelInvoke("Color");
    }
}