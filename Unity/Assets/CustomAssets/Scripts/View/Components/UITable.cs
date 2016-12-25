using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class UITable : MonoBehaviour {

    //[SerializeField] 

    [SerializeField] protected List<Cell> Cells;
    [SerializeField] protected int Columns;
    [SerializeField] protected int Rows;

    protected void OnEnable()
    {
        
    }

    protected void OnDisable()
    {
        
    }


}
[Serializable]
public class Cell
{
    [SerializeField]
    public int Index;
    [SerializeField]
    public GameObject Transform;
}
