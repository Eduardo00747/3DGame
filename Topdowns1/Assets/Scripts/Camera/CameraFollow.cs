using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Refer�ncia ao objeto que a c�mera ir� seguir.
    public float smoothSpeed = 0.125f; // Velocidade suavizada da c�mera.

    private Vector3 offset; // Offset da c�mera em rela��o ao objeto que ela segue.

    void Start()
    {
        // Calcular o offset da c�mera em rela��o ao objeto que ela segue.
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        // Definir a posi��o da c�mera para que ela siga o objeto com suavidade.
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
