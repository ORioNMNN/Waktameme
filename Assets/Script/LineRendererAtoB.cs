using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererAtoB : MonoBehaviour
{
    private LineRenderer lineRenderer;
    // Use this for initialization
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false;

    }


    public void Play(Vector3 from, Vector3 to)
    {
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, from);
        lineRenderer.SetPosition(1, to);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHP>().TakeDamage();
            Debug.Log("Crush");
        }

    }

    public void Stop()
    {
        lineRenderer.enabled = false;
    }

}
