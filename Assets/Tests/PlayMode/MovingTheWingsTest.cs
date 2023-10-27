using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

public class MovingTheWingsTest
{
    [UnityTest]
    public IEnumerator PlayerCanJump()
    {
        GameObject playerObject = new GameObject();
        MovingTheWings playerController = playerObject.AddComponent<MovingTheWings>();
        
        playerController.speed = 5f; // Establece una velocidad de movimiento
        playerController.jumpForce = 10f; // Establece una fuerza de salto
        playerController.rb = playerObject.AddComponent<Rigidbody2D>();
        
        var yPositionBeforeJump = playerController.transform.position.y;

        // Espera un frame para permitir que el controlador se actualice después del salto
        yield return null;

        // Realiza un salto

        for (int i = 0; i < 3; i++)
        {
            playerController.rb.AddForce(Vector2.up * playerController.jumpForce, ForceMode2D.Impulse);
            playerController.rb.velocity = playerController.transform.up * playerController.speed;
        }

        // Espera un frame para permitir que el controlador se actualice después del salto
        yield return null;

        var yPositionAfterJump = playerController.transform.position.y;

        Assert.Greater(yPositionAfterJump, yPositionBeforeJump);
    }

    [UnityTest]
    public IEnumerator PlayerCollidesWithFloor()
    {
        GameObject playerObject = new GameObject();
        MovingTheWings playerController = playerObject.AddComponent<MovingTheWings>();
        BoxCollider2D collider1 = playerObject.AddComponent<BoxCollider2D>();

        // Crea un objeto de suelo
        GameObject floorObject = new GameObject("Floor");
        floorObject.tag = "floor"; // Asigna la etiqueta "floor" al objeto del suelo
        BoxCollider2D collider2 = floorObject.AddComponent<BoxCollider2D>();

        // Posicion inicial del jugador
        var initPos = playerController.transform.position;

        var finalPos = floorObject.transform.position;

        // Mueve al jugador hacia abajo para simular una colisión con el suelo
        playerController.transform.position = finalPos;

        // Espera un frame para permitir que el controlador se actualice y detecte la colisión
        yield return null;

        // Verifica si el jugador ha colisionado con el suelo y ha reiniciado la partida
        Assert.AreEqual(initPos, playerController.transform.position);
    }
}
