using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonOpener : MonoBehaviour
{
    public NumberDisplay numbers;

    private void Start()
    {
    }

    public void ButtonOpen()
    {
        Application.OpenURL("https://nhentai.net/g/" + numbers.numberS + "/");
    }
}
