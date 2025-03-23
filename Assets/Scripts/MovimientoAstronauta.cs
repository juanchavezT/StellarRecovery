using UnityEngine;

public class MovimientoAstronauta : MonoBehaviour
{
    public float velocidadMovimiento = 5f; // Velocidad del movimiento
    private Vector3 posicionObjetivo; // La posición hacia la que el jugador se moverá

    void Start()
    {
        // Establecer la posición inicial del jugador
        transform.position = new Vector3(195f, 117f, -143.5f);
        posicionObjetivo = transform.position; // Iniciar con la misma posición
    }

    void Update()
    {
        // Entrada del teclado
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Calcular la posición objetivo
        posicionObjetivo += new Vector3(movimientoHorizontal, movimientoVertical, 0f) * velocidadMovimiento * Time.deltaTime;

        // Mantener el eje Z fijo
        posicionObjetivo.z = -143.5f;

        // Interpolar suavemente hacia la posición objetivo
        transform.position = Vector3.Lerp(transform.position, posicionObjetivo, 0.1f);
    }
}
