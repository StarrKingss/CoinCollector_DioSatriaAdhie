using UnityEngine;

public class PenerimaEvent : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        PemancarEvent.SaatTombolDitekan += Respon;
    }
    private void OnDisable()
    {
        PemancarEvent.SaatTombolDitekan -= Respon;
    }
    void Respon()
    {
        Debug.Log("Tombol ditekan, saya merespon");
    }
}
    