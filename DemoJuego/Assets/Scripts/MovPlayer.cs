using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayer : MonoBehaviour
{
    public float runSpeed = 1; // Movimiento Horizontal
    public float jumpSpeed = 2;

    Rigidbody2D Cuerpo2D; // Referencia al Rigidbody

    public SpriteRenderer spriteRenderer;
    public Animator animator;


    void Start()
    {
        Cuerpo2D = GetComponent<Rigidbody2D>();  // Meter el componente a la variable del personaje (Rigidbody)
    }


    void FixedUpdate()
    {
        if (Input.GetKey("d")) // Moverse con la letra D para la Derecha, si quisiera agregar otra letra para la misma accion deberia agregar los " || " que significan "o".
        {
            Cuerpo2D.velocity = new Vector2(runSpeed, Cuerpo2D.velocity.y);
            spriteRenderer.flipX = false; // Cuando vayamos a la derecha el flip(girar de lado el personaje) este desactivado.
            animator.SetBool("Correr", true);
        }

        else if (Input.GetKey("a")) // Si preciono la letra A es para ir a al izquierda.
        {
            Cuerpo2D.velocity = new Vector2(-runSpeed, Cuerpo2D.velocity.y);
            spriteRenderer.flipX = true; // Cuando vayamos a la izquierda el flip(girar de lado el personaje) este activado, asi miraria hacia ese lado.
            animator.SetBool("Correr", true);
        }
        else // si no apreto el personaje debe quedarse en su lugar
        {
            Cuerpo2D.velocity = new Vector2(0, Cuerpo2D.velocity.y);
            animator.SetBool("Correr", false);
        }
        if (Input.GetKey("w") && TocarPiso.contactoPiso) // Para saltar la W, "&&" es para saber que se cumpla esa condicion y la que viene
        {
            Cuerpo2D.velocity = new Vector2(Cuerpo2D.velocity.x, jumpSpeed);
        }

        if (TocarPiso.contactoPiso == false)
        {
            animator.SetBool("Salto", true);
            animator.SetBool("Correr", false); // Cuando estemos saltando y estemos en el aire no podremos estar corriendo
        }
        if (TocarPiso.contactoPiso == true)
        {
            animator.SetBool("Salto", false); // Cuando estemos tocando piso Saltar debe ser false
        }

    }

}
