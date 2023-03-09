using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharManager : MonoBehaviour
{
    [SerializeField]
    public GameObject[] character;


    public void Wakgood()
    {
        falseActive();
        character[0].SetActive(true);
    }

    public void Ine()
    {

        falseActive();
        character[1].SetActive(true);
    }

    public void Lilpa()
    {

        falseActive();
        character[2].SetActive(true);
    }

    public void Jing()
    {

        falseActive();
        character[3].SetActive(true);
    }

    public void Jururu()
    {

        falseActive();
        character[4].SetActive(true);
    }

    public void Gosegu()
    {

        falseActive();
        character[5].SetActive(true);
    }

    public void Viichan()
    {

        falseActive();
        character[6].SetActive(true);
    }

    void falseActive()
    {
        for (int i = 0; i < character.Length; i++)
        {
            character[i].SetActive(false);
        }
    }
}
