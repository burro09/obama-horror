using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string targetTag = "Player";
    public float moveSpeed = 3f;
    public float rotateSpeed = 5f;

    void Update()
    {
        // Troviamo il giocatore
        GameObject player = GameObject.FindGameObjectWithTag(targetTag);

        // Se non troviamo il giocatore, usciamo dalla funzione
        if (player == null)
        {
            Debug.LogWarning("Player not found with tag " + targetTag);
            return;
        }

        // Calcoliamo la direzione in cui guardare
        Vector3 directionToPlayer = player.transform.position - transform.position;
        directionToPlayer.y = 0f; // Assicuriamoci che il nemico non guardi mai verso l'alto o il basso

        // Calcoliamo la rotazione per guardare verso il giocatore
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);

        // Ruotiamo gradualmente il nemico per guardare verso il giocatore
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

        // Muoviamo il nemico nella direzione del proprio avanti
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}



