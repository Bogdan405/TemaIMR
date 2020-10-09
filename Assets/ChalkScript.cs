using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
namespace VRTK
{
    public class ChalkScript : VRTK_InteractableObject
    {
        
        public DrawingPen drawingPen;
        public void OnEnable()
        {
            
            this.InteractableObjectUsed += StartDrawing;
            this.InteractableObjectUnused += StopDrawing;

        }

        public void OnDisable()
        {
            this.InteractableObjectUsed -= StartDrawing;
            this.InteractableObjectUnused -= StopDrawing;
        }

        protected virtual void StartDrawing(object sender,InteractableObjectEventArgs e)
        {
            drawingPen.StartDrawing();
        }

        protected virtual void StopDrawing(object sender, InteractableObjectEventArgs e)
        {
            drawingPen.StopDrawing();
        }
    }
}