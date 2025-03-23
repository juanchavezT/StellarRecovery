using UnityEngine;

public class ControladorInicioJuego : MonoBehaviour
{
    public MovimientoAstronauta jugador; // Referencia al script MovimientoAstronauta

    public void IniciarJuego()
    {
        
        if (jugador != null)
        {
            jugador.enabled = true; // Activar el script de movimiento
            Debug.Log("¡El juego ha comenzado!");
        }
        else
        {
            Debug.LogError("La referencia al jugador no está configurada en el Inspector.");
        }
    }
}
