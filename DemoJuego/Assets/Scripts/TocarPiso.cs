using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TocarPiso : MonoBehaviour
{

    public static bool contactoPiso;  // El static es para poder usar esta variable dentro de otro Script

    private void OnTriggerEnter2D(Collider2D collision)
    {
        contactoPiso = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        contactoPiso = false;
    }
}
