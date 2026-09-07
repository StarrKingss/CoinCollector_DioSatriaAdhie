using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private int hp = 100;
    public float ms = 2f;
    protected Transform Player;

    [Header ("Pengaturan State Machine")]
    [SerializeField] private float jarakDeteksi = 6f;
    [SerializeField] private float jarakSerang = 1.2f;

    [SerializeField] private float jedaSerang = 1f;

    //State Sekarang 

    private StateZombie currentState = StateZombie.IDLE;
    private float waktuSerangTerakhir; 


    protected virtual void Start()
    {
        GameObject PlayerObj = GameObject.FindGameObjectWithTag("Player");
        if (PlayerObj != null)
        {
            Player = PlayerObj.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        PeriksaTransisi();
        
        // switch (currentState)
        // {
        //     case StateZombie.IDLE: PerilakuIdle(); break;
        //     case StateZombie.PATROL: PerilakuPatrol(); break ;
        //     case StateZombie.CHASE: PerilakuChase(); break;
        //     case StateZombie.ATTACK: PerilakuAttack(); break;
        // }
    }

    public void kejar()
    {
        if (Player == null) return;

        transform.position = Vector2.MoveTowards(
            transform.position,
            Player.position,
            ms * Time.deltaTime
        );
    }
    public virtual void Serang()
    {
        Debug.Log("Enemy Menyerang");
    }
    public float JarakKePlayer()
    {
        if(Player == null) return Mathf.Infinity;
        return Vector2.Distance(transform.position, Player.position);
    }    

    void PeriksaTransisi()
    {
        float jarak = JarakKePlayer();

        if (jarak <= jarakSerang)
        {
            currentState = StateZombie.ATTACK;
        }
        else if (jarak <= jarakDeteksi)
        {
            currentState = StateZombie.CHASE;
        }
        else
        {
            currentState = StateZombie.PATROL;
        }
    }

    void PerilakuPatrol()
    {
        Debug.Log("Zombie Sedang Patroli");
    }

    void PerilakuChase()
    {
         kejar();

        Debug.Log("Zombie Sedang Mengejar Player");
    }

    void PerilakuAttack()
    {
        Debug.Log("Zombie Sedang Menyerang Player");
    }

    void PerilakuIdle()
    {
        Debug.Log("Zombie Sedang Idle(?)");
    }

    public void KenaDamage(int jumlah)
    {
        hp -= jumlah;
        if (hp <= 0)
        {
            Mati();
        }
    }

    private void Mati()
    {
        Debug.Log($"{gameObject.name} Mati");
        Destroy(gameObject);
    }
}