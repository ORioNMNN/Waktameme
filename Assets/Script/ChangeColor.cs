using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{

    private Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
        image.color = Color.magenta;
    }

}
