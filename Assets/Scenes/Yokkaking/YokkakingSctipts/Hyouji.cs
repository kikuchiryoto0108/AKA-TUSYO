using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyouji : MonoBehaviour
{
    public GameObject hyouji;

    // Update is called once per frame
    void Update()
    {
        if (VarScripts.ACTION == true)
        {
            hyouji.gameObject.SetActive(true);
        }
        else if (VarScripts.ACTION == false)
        {
            hyouji.gameObject.SetActive(false);
        }
    }
}
