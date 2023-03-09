using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Referência ao objeto que a câmera irá seguir.
    public float smoothSpeed = 0.125f; // Velocidade suavizada da câmera.

    private Vector3 offset; // Offset da câmera em relação ao objeto que ela segue.

    void Start()
    {
        // Calcular o offset da câmera em relação ao objeto que ela segue.
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        // Definir a posição da câmera para que ela siga o objeto com suavidade.
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
