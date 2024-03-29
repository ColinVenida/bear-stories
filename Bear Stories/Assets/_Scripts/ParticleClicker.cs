﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ParticleClicker : MonoBehaviour, IPointerClickHandler
{

    public Camera camera;
    public Canvas canvas;
    public ParticleSystem clickParticles;

    public void OnPointerClick( PointerEventData pointerEventData )
    {
        Vector2 pointPosition = pointerEventData.position;
        RectTransform particleRT = clickParticles.GetComponent<RectTransform>();
        Vector2 localPoint;

        RectTransformUtility.ScreenPointToLocalPointInRectangle( canvas.GetComponent<RectTransform>(), pointPosition,
           camera, out localPoint );

        particleRT.anchoredPosition = localPoint;        
        clickParticles.Play();        
    }
}
