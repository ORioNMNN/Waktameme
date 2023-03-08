using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] character;


    public void good()
    {
        character[0].SetActive(true);
    }

    public void ine()
    {
        character[1].SetActive(true);
    }

    public void lilpa()
    {
        character[2].SetActive(true);
    }

    public void jing()
    {
        character[3].SetActive(true);
    }

    public void jururu()
    {
        character[4].SetActive(true);
    }

    public void gosegu()
    {
        character[5].SetActive(true);
    }

    public void viichan()
    {
        character[6].SetActive(true);
    }



}
