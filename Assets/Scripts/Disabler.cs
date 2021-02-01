using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disabler : MonoBehaviour
{
    public GameObject Holder;

    // Start is called before the first frame update
    void Awake()
    {
        Holder.SetActive(false);
    }
}
