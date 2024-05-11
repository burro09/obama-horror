using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField][Range(0.5f, 2f)] float mouseSense = 1f;
    [SerializeField][Range(-90f, 90f)] float maxLookUpAngle = 60f;
    [SerializeField][Range(-90f, 90f)] float maxLookDownAngle = -60f;

    private Vector2 currentRotation = Vector2.zero;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Otteniamo l'input del mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSense;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSense;

        // Aggiorniamo la rotazione attuale
        currentRotation.x += mouseX;
        currentRotation.y -= mouseY; // Il segno è invertito per invertire il movimento verticale

        // Limitiamo la rotazione verticale tra i valori massimi impostati
        currentRotation.y = Mathf.Clamp(currentRotation.y, maxLookDownAngle, maxLookUpAngle);

        // Ruotiamo il giocatore in base all'input orizzontale
        player.transform.rotation = Quaternion.Euler(0f, currentRotation.x, 0f);

        // Ruotiamo la telecamera in base all'input verticale
        transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0f);
    }
}

