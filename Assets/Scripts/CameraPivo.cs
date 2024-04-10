using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivo : MonoBehaviour
{

    public Transform alvo;


    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, alvo.position, 0.20f);
    }
}
