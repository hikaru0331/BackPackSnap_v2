using System.Collections.Generic;
using UnityEngine;

public class MouseEffectManager : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Camera mainCamera;

    private int posCount = 0;
    private float interval = 0.1f;

    private void Start()
    {
        //lineRendererの色をインスペクター上のものにする
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = lineRenderer.startColor;
    }

    private void Update()
    {
        Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            lineRenderer.enabled = true;
            SetPosition(mousePos);
        }                
        else if (Input.GetMouseButtonUp(0))
        {
            posCount = 0;
            lineRenderer.enabled = false;
        }
            
    }

    private void SetPosition(Vector2 pos)
    {
        if (!PosCheck(pos)) return;

        posCount++;
        lineRenderer.positionCount = posCount;
        lineRenderer.SetPosition(posCount - 1, pos);
    }

    private bool PosCheck(Vector2 pos)
    {
        if (posCount == 0) return true;

        float distance = Vector2.Distance(lineRenderer.GetPosition(posCount - 1), pos);
        if (distance > interval)
            return true;
        else
            return false;

    }
}