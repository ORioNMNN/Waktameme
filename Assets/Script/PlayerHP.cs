using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    }

    public bool TakeDamage()
    {
        if( currentHP > 1)
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

    private IEnumerator HitColorAnimation()
    {
        spriteRenderer.color = Color.magenta;

        yield return new WaitForSeconds(0.5f);

        spriteRenderer.color = new Color(0.04156689f, 0.4150943f, 0, 1);

    }


}