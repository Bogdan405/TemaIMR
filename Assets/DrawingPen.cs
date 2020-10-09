using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DrawingPen : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private GameObject gameObject;
    private Vector3 lastPos;
    public bool shouldDraw;
    private bool lineStarted = false;
    private int linesDrawn = 0;
    public Timer timer;
    void Start()
    {
        init();
    }

    public void init()
    {
        gameObject = new GameObject("MyGameObject" + linesDrawn);
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.SetColors(new Color(
        UnityEngine.Random.Range(0f, 1f),
        UnityEngine.Random.Range(0f, 1f),
        UnityEngine.Random.Range(0f, 1f)
          ), new Color(
                UnityEngine.Random.Range(0f, 1f),
                UnityEngine.Random.Range(0f, 1f),
                UnityEngine.Random.Range(0f, 1f)
          ));
        lineRenderer.startWidth = 0.02f;
        lineRenderer.endWidth = 0.02f;
        lineRenderer.useWorldSpace = true;
        lineRenderer.positionCount = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (shouldDraw && !timer.isRunning)
        {
            lastPos = this.transform.position;
            if (!lineStarted)
            {
                linesDrawn +=1;
                lineStarted = true;
                lineRenderer.positionCount = 2;
                lineRenderer.SetPosition(0, lastPos);
                lineRenderer.SetPosition(1, lastPos);
            }
            else
            {
                lastPos = this.transform.position;
                lineRenderer.positionCount +=1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, lastPos);
            }
            
            timer.RestartTimer();
        }
    }

    public void StartDrawing()
    {
        shouldDraw = true;
    }
    public void StopDrawing()
    {
        shouldDraw = false;
        lineStarted = false;
        init();
    }
}
