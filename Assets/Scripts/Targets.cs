using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    private float timeDestroy = 2f;
    private GameManager gameManagerScript;

    [SerializeField] private int points;
    public ParticleSystem explosionParticle;

    void Start()
    {
        // Destruye el objeto tras 2 segundos
        Destroy(gameObject, timeDestroy);

        gameManagerScript = FindObjectOfType<GameManager>();
    }

    
    private void OnMouseDown()
    {
        if (!gameManagerScript.gameOver)
        {
            gameManagerScript.UpdateScore(points);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }

        if (gameObject.CompareTag("Good"))
        {
           
            
            Destroy(gameObject);
            gameManagerScript.targetPositions.Remove(transform.position);


            
            //Sistema de particulas
            // Musiquita de ¡Bien Hecho!
        }

        else if (gameObject.CompareTag("Bad"))
        {
            Destroy(gameObject);
            gameManagerScript.missCounter += 1;

            if (gameManagerScript.missCounter >= gameManagerScript.totalMisses)
            {
                gameManagerScript.GameOver();
            }

            // Game Over
            // Restar Puntos
            // Quitar Puntos
            // Musiquita
            // Sistema de particulas
        }

        
        
       
    }

    private void OnDestroy()
    {
        gameManagerScript.targetPositions.Remove(transform.position);
    }
}
