using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;


public class ControladorBoton : MonoBehaviour
{
    public HerramientasJugador jugador; // Referencia al script del jugador
    public Button botonGuantes;
    public Button botonPinzas;
    public Button botonEscoba;
    public Button botonPodadora;
    public Button botonSemillas; // Botón de Semillas

    private int contadorSemillas = 0; // Contador para el botón Semillas
    private int rangoSemillas = 3; // Número de veces para bloquear el botón

    private bool guantesUsado = false; // Estado de botón "Guantes"
    private bool pinzasUsado = false; // Estado de botón "Pinzas"
    private bool escobaUsado = false; // Estado de botón "Escoba"
    private bool podadoraUsado = false; // Estado de botón "Podadora"

    private List<GameObject> semillas; // Lista de objetos con tag "semilla"

    public TextMeshProUGUI mensajeFinalizacion; // Texto para mostrar mensaje de fin del juego

    void Start()
    {
        // Deshabilitar el botón "Semillas" al inicio
        botonSemillas.interactable = false;

        // Buscar todos los objetos con el tag "semilla" y desactivarlos
        semillas = new List<GameObject>(GameObject.FindGameObjectsWithTag("semilla"));
        foreach (GameObject semilla in semillas)
        {
            semilla.SetActive(false); // Ocultar todos los objetos con el tag "semilla"
        }

        // Asegurarnos de que el mensaje de finalización esté oculto al inicio
        if (mensajeFinalizacion != null)
        {
            mensajeFinalizacion.gameObject.SetActive(false);
        }
    }

    public void BotonGuantes()
    {
        jugador.ActivarEliminacion("organica");
        guantesUsado = true; // Marcar botón como usado
        Debug.Log("Botón Guantes activado: puede eliminar objetos orgánicos.");
        RevisarDesbloqueoSemillas();
    }

    public void BotonPinzas()
    {
        jugador.ActivarEliminacion("vidrio,metal");
        pinzasUsado = true; // Marcar botón como usado
        Debug.Log("Botón Pinzas activado: puede eliminar objetos de vidrio y metal.");
        RevisarDesbloqueoSemillas();
    }

    public void BotonEscoba()
    {
        jugador.ActivarEliminacion("plastico,papel");
        escobaUsado = true; // Marcar botón como usado
        Debug.Log("Botón Escoba activado: puede eliminar objetos de plástico y papel.");
        RevisarDesbloqueoSemillas();
    }

    public void BotonPodadora()
    {
        jugador.ActivarEliminacion("cesped");
        podadoraUsado = true; // Marcar botón como usado
        Debug.Log("Botón Podadora activado: puede eliminar objetos de césped.");
        RevisarDesbloqueoSemillas();
    }

    public void BotonSemillas()
    {
        // Activar los objetos "semilla" en la escena
        foreach (GameObject semilla in semillas)
        {
            semilla.SetActive(true); // Mostrar los objetos con el tag "semilla"
        }

        IncrementarContador("Semillas");
        Debug.Log("Objetos con tag 'semilla' activados.");
        FinalizarJuego(); // Llamar al método de finalización del juego
    }

    private void RevisarDesbloqueoSemillas()
    {
        // Verificar si todos los demás botones han sido usados
        if (guantesUsado && pinzasUsado && escobaUsado && podadoraUsado)
        {
            botonSemillas.interactable = true; // Desbloquear el botón Semillas
            Debug.Log("Botón Semillas desbloqueado.");
        }
    }

    private void FinalizarJuego()
    {
        // Mostrar mensaje de finalización si el texto está asignado
        if (mensajeFinalizacion != null)
        {
            mensajeFinalizacion.gameObject.SetActive(true); // Mostrar mensaje
            mensajeFinalizacion.text = "¡Felicidades! Has completado el juego."; // Cambia el texto aquí si lo deseas
        }

        // Detener el tiempo del juego
        Time.timeScale = 0f;
        Debug.Log("El juego ha terminado.");
    }

    public void IncrementarContador(string tipoBoton)
    {
        switch (tipoBoton)
        {
            case "Semillas":
                contadorSemillas++;
                if (contadorSemillas >= rangoSemillas)
                {
                    botonSemillas.interactable = false; // Bloquear el botón "Semillas"
                    Debug.Log("El botón Semillas ha sido bloqueado.");
                }
                break;

            // Casos restantes para otros botones...
        }
    }
}
