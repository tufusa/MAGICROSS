using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public string Number = "0";

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == Number)
        {
            this.Number = "0";
        }
    }

    public void BoxExit()
    {
        GameObject.Find(this.Number).GetComponent<NumberController>().Exit();
    }
}
