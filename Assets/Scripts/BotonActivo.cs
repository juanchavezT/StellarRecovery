using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonActivo : MonoBehaviour
{
    public Desbloquear scriptDesbloquear; // Referencia al script Desbloquear
    public Button[] botones; // Lista de botones en el Canvas
    private Button botonActivo; // Botón actualmente activo

    void Update()
    {
        // Verificar si el usuario está tocando algún botón
        if (scriptDesbloquear != null && scriptDesbloquear.EstasTocando)
        {
            // Iterar por los botones para detectar cuál está seleccionado
            foreach (Button boton in botones)
            {
                if (EventSystem.current.currentSelectedGameObject == boton.gameObject)
                {
                    ActivarBoton(boton);
                }
            }
        }
    }

    private void ActivarBoton(Button boton)
    {
        if (botonActivo != null)
        {
            // Opcional: Restaurar estilo al botón anterior si estaba activo
            botonActivo.interactable = true;
        }

        // Activar y notificar el nuevo botón
        botonActivo = boton;
        botonActivo.interactable = false; // Opcional: Deshabilitar la interacción si es necesario
        Debug.Log("Botón activo: " + botonActivo.name);
    }
}
