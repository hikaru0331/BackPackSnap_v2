using System.Collections.Generic;
using UnityEngine;

public class MouseEffectManager : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Camera mainCamera;

    //パーティクルのプレハブを入れる変数
    [SerializeField] private GameObject mouseBurstPrefab;
    //インスタンスされたパーティクルを入れる変数
    private GameObject mouseBurst;

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

            //プレハブを生成し、変数に代入→代入されたパーティクルを0.5秒後に破壊
            mouseBurst = Instantiate(mouseBurstPrefab, mousePos, Quaternion.identity);
            Destroy(mouseBurst, 0.5f);
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