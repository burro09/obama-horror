using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public float pickupRange = 2f; // Raggio massimo per raccogliere l'oggetto
    public KeyCode pickupKey = KeyCode.E; // Tasto per raccogliere l'oggetto

    private GameObject player; // Giocatore
    private GameObject currentObject; // Oggetto attualmente guardato

    void Start()
    {
        // Assicurati che il giocatore sia presente nel tuo gioco (puoi usare il tag "Player" per identificarlo)
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        // Lanciamo un raggio in avanti dal giocatore
        RaycastHit hit;
        if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, pickupRange))
        {
            // Se colpisce un oggetto raccoglibile e non stiamo già tenendo un oggetto
            if (hit.collider.CompareTag("Collezionabile") && currentObject == null)
            {
                currentObject = hit.collider.gameObject; // Salviamo l'oggetto corrente
                Debug.Log("Guardando: " + currentObject.name);
            }
        }
        else
        {
            currentObject = null; // Se non stiamo guardando nulla, azzeriamo l'oggetto corrente
        }

        // Se abbiamo un oggetto guardato e premiamo il tasto di raccolta, raccogliamo l'oggetto
        if (currentObject != null && Input.GetKeyDown(pickupKey))
        {
            Pickup();
        }
    }

    void Pickup()
    {
        // Fai ciò che vuoi fare quando raccogli l'oggetto
        Debug.Log("Hai raccolto: " + currentObject.name);
        // Esempio: Disattiva l'oggetto e fai qualcos'altro
        currentObject.SetActive(false);
        // Azzeriamo l'oggetto corrente
        currentObject = null;
    }
}



