using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerramientasJugador : MonoBehaviour
{
    private string tagPermitido = ""; // Tag permitido actualmente
    private ControladorBoton controladorBoton; // Referencia al script ControladorBoton

    void Start()
    {
        // Buscar automáticamente el controlador de botones
        controladorBoton = FindObjectOfType<ControladorBoton>();

        // Validar que controladorBoton no sea nulo
        if (controladorBoton == null)
        {
            Debug.LogError("ControladorBoton no encontrado en la escena. Asegúrate de que está presente.");
        }
    }

    // Método para activar la eliminación con un tag
    public void ActivarEliminacion(string tag)
    {
        tagPermitido = tag; // Asignar el tag permitido
        Debug.Log($"Tag permitido asignado: {tagPermitido}");
    }

    // Detectar colisiones físicas (sin Is Trigger)
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Colisión detectada con: {collision.gameObject.name}");
        ProcesarEliminacion(collision.gameObject);
    }

    // Detectar activadores (si Is Trigger está activado)
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger detectado con: {other.gameObject.name}");
        ProcesarEliminacion(other.gameObject);
    }

    private void ProcesarEliminacion(GameObject objeto)
    {
        // Validar que controladorBoton no sea nulo
        if (controladorBoton == null)
        {
            Debug.LogError("ControladorBoton es nulo en ProcesarEliminacion.");
            return;
        }

        if (string.IsNullOrEmpty(tagPermitido)) 
        {
            Debug.Log($"Tag permitido actual: {tagPermitido}");
            return;
        }

        // Comparar el tag del objeto con los tags permitidos
        foreach (string tag in tagPermitido.Split(','))
        {
            if (objeto.CompareTag(tag))
            {
                Debug.Log($"Eliminando objeto con tag '{tag}': {objeto.name}");
                Destroy(objeto); // Eliminar el objeto de la escena

                // Incrementar el contador según el tag permitido y botón asociado
                if (tagPermitido.Contains("organica"))
                {
                    controladorBoton.IncrementarContador("Guantes");
                }
                else if (tagPermitido.Contains("vidrio") || tagPermitido.Contains("metal"))
                {
                    controladorBoton.IncrementarContador("Pinzas");
                }
                else if (tagPermitido.Contains("plastico") || tagPermitido.Contains("papel"))
                {
                    controladorBoton.IncrementarContador("Escoba");
                }
                else if (tagPermitido.Contains("cesped"))
                {
                    controladorBoton.IncrementarContador("Podadora");
                }

                return; // Salir después de eliminar un objeto
            }
        }

        Debug.Log($"El objeto {objeto.name} tiene un tag no permitido: {objeto.tag}");
    }
}
