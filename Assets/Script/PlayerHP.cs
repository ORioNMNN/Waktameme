using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private GameObject[] imageHP;
    private int          currentHP;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        currentHP = imageHP.Length;
        spriteRenderer = GetComponent<SpriteRenderer>();
        Color origin = spriteRenderer.color;
        
    }

    public bool TakeDamage()
    {
        if( currentHP >= 1)
        {
            currentHP--;
            imageHP[currentHP].SetActive(false);
        }

        else
        {
            return true;
        }

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        if (currentHP <= 0)
        {
            Debug.Log("Player HP : Die");

        }

        return false;
    }

    public bool TakeHeal()
    {
        if ( currentHP >= 1 )
        {
            currentHP++;
            imageHP[currentHP + 1].SetActive(true);

        }

        else
        {
            return true;
        }

        return false;
    }

  
    private IEnumerator HitColorAnimation()
    {

        Color origin = spriteRenderer.color;
        Debug.Log(origin);
        spriteRenderer.color = Color.magenta;

        yield return new WaitForSeconds(0.5f);

        spriteRenderer.color = origin;

    } 
}