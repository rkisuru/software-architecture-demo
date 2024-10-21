using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public static Generator instance;

    [SerializeField] Transform generator;

    [SerializeField] GameObject[] bubbles;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        StartCoroutine(Generate());
    }

    private IEnumerator Generate()
    {
        while (true)
        {
            RandomObject();
            Interval();
            if (bubbles[RandomObject()].activeSelf == false)
            {
                bubbles[RandomObject()].SetActive(true);
            }
            yield return new WaitForSeconds(Interval());
        }
    }

    private int Interval()
    {
        int interval = Random.Range(1, 4);
        return interval;
    }

    private int RandomObject()
    {
        int randomObject = Random.Range(0, bubbles.Length);
        return randomObject;    
    }
}
