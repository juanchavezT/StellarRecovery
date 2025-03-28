﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Spin the object at a specified speed
/// </summary>
public class SpinFree : MonoBehaviour {
    [Tooltip("Spin: Yes or No")]
    public bool spin;
    [Tooltip("Spin the parent object instead of the object this script is attached to")]
    public bool spinParent;
    public float speed = 10f;

    [HideInInspector]
    public bool clockwise = true;
    [HideInInspector]
    public float direction = 1f;
    [HideInInspector]
    public float directionChangeSpeed = 2f;

    void Update() {
        // Actualizar la dirección gradualmente hasta llegar a 1
        if (direction < 1f) {
            direction += Time.deltaTime / (directionChangeSpeed / 2);
        }

        // Si spin está activado, hacer rotar el objeto o su padre
        if (spin) {
            // Verificar si el objeto padre existe antes de intentar rotarlo
            if (spinParent && transform.parent != null) {
                if (clockwise)
                    transform.parent.transform.Rotate(Vector3.up, (speed * direction) * Time.deltaTime);
                else
                    transform.parent.transform.Rotate(-Vector3.up, (speed * direction) * Time.deltaTime);
            } else {
                if (clockwise)
                    transform.Rotate(Vector3.up, (speed * direction) * Time.deltaTime);
                else
                    transform.Rotate(-Vector3.up, (speed * direction) * Time.deltaTime);
            }
        }
    }
}
