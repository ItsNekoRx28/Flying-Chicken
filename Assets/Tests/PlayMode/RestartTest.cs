using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class RestartTest
{

    [UnityTest]
    public IEnumerator TestCollisionWithWall()
    {
        // Jugador
        GameObject playerObject = new GameObject();
        Restart playerController = playerObject.AddComponent<Restart>();
        BoxCollider2D collider1 = playerObject.AddComponent<BoxCollider2D>();
        collider1.isTrigger = true;

        // Crea un objeto de suelo
        GameObject wallObject = new GameObject();
        wallObject.tag = "wall"; // Asigna la etiqueta "floor" al objeto del suelo
        BoxCollider2D collider2 = wallObject.AddComponent<BoxCollider2D>();
        collider2.isTrigger = true;

        var finalPos = wallObject.transform.position;

        // Mueve al jugador hacia el muro para simular una colisión con el suelo
        playerController.transform.position = finalPos;

        // Espera un frame para permitir que el controlador se actualice y detecte la colisión
        yield return null;

        // Verifica si el jugador ha colisionado con el muro
        Assert.AreEqual(finalPos, playerController.transform.position);

        // Verifica que el tiempo se haya detenido
        Assert.AreEqual(0f, Time.timeScale);
    }
}
