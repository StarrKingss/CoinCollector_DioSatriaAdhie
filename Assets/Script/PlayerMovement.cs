using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float kecepatan = 5f;
    public int skor = 0;
    public TextMeshProUGUI textSkor;

    private Vector2 arahGerak;
    private GameManager gameManager;

    void Start()
    {
        // Cari GameManager di scene
        gameManager = FindFirstObjectByType<GameManager>();
    }

    // Dipanggil otomatis oleh Player Input
    void OnMove(InputValue value)
    {
        arahGerak = value.Get<Vector2>();
    }

    void Update()
    {
        Vector3 arah = new Vector3(arahGerak.x, arahGerak.y, 0);
        transform.position += arah * kecepatan * Time.deltaTime;
    }

    // Dipanggil saat menyentuh objek Trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        // Jika menyentuh koin
        if (other.CompareTag("Coin"))
        {
            // Hapus koin
            Destroy(other.gameObject);

            // Tambah skor
            skor++;
            Debug.Log("Skor: " + skor);
            textSkor.text = "Skor: " + skor;

            // Beri tahu GameManager bahwa ada koin yang diambil
            if (gameManager != null)
            {
                gameManager.AmbilKoin();
            }
        }
    }
}