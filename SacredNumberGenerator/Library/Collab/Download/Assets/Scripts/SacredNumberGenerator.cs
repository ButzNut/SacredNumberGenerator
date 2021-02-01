using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SacredNumberGenerator : MonoBehaviour
{
    public List<int> Lists = new List<int>();
    [SerializeField]
    private Transform SpawnPoint = null;

    public Text number;
    public int sacredNumber;
    public int numberToShow;
    public int[] saveNumbers;

    public GameObject SacredHolder;

    [SerializeField]
    public static SacredNumberGenerator instance;

    private void Start()
    {
        saveNumbers = PlayerPrefsX.GetIntArray("SacredNumber");
        Lists.AddRange(saveNumbers);

        instance = this;
    }

    public void Update()
    {
       saveNumbers = Lists.ToArray();
        PlayerPrefsX.SetIntArray("SacredNumber", saveNumbers);

    }

    public void GenerateNumber()
    {
        sacredNumber = Random.Range(1, 326999);

        if(!Lists.Contains(sacredNumber))
        {
            StartCoroutine(SaveNumber());
        }
            number.text = sacredNumber.ToString("D6");
    }

    IEnumerator SaveNumber()
    {
        Lists.Add(sacredNumber);
        numberToShow = sacredNumber;
        yield return new WaitForSeconds(1);
        sacredNumber = 0;
    }

    public void deleteNumbers()
    {
        Lists.Clear();
        saveNumbers = Lists.ToArray();
    }

    public void ShowNumbers()
    {
        SacredHolder.SetActive(true);
        Debug.Log("Activated");
    }

    public void HideNumbers()
    {
        SacredHolder.SetActive(false);
        foreach (Transform child in SpawnPoint)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void openNumber()
    {
        Application.OpenURL("https://nhentai.net/g/" + numberToShow.ToString("D3") + "/");
    }
}