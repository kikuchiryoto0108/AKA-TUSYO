using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACTIONsettei : MonoBehaviour
{

    public bool action = false;

    // Start is called before the first frame update
    void Start()
    {
        VarScripts.ACTION = action;
    }
}
