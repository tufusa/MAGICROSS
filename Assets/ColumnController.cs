using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColumnController : MonoBehaviour
{
    bool ClearFlag = false;
    List<int> sum;
    int i;
    public Columns[] columns;

    void Start()
    {
        sum = new List<int>(columns.Length);
        for (i = 0; i < columns.Length; i++) sum.Add(0);
    }
    void Update()
    {
        for (i = 0; i < this.columns.Length; i++)
        {
            sum[i] = 0;
            Debug.Log(columns[1].column[0]);
            if (columns.All(columnelement => columnelement.column.All(box => box.GetComponent<BoxController>().Number != "0")) && !this.ClearFlag)
            {
                foreach (GameObject columnelement in this.columns[i].column)
                {
                    sum[i] += Convert.ToInt32(columnelement.GetComponent<BoxController>().Number);
                }
                if (sum.Distinct().Count() == 1)
                {
                    GameObject.FindWithTag("GameController").GetComponent<GameController>().Clear();
                    this.ClearFlag = true;
                }
            }
        }

    }
}

[System.Serializable]
public class Columns
{
    public GameObject[] column;
}