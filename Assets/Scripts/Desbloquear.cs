using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Desbloquear : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
   public bool EstasTocando;

   public void OnPointerDown(PointerEventData eventData)
   {
       EstasTocando = true;
   }

   public void OnPointerUp(PointerEventData eventData)
   {
       EstasTocando = false;
   }
}
