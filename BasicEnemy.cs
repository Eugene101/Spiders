using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public float enemyHp;
    
    public float enemyArmor;
    public int enemyDamage;
    public float enemySpeed;
    public float enemyValue;
    public float damageTime = 3f;
    public float _currentHealthEnemy;
    public float pollution = 0f;
    public float pollutionCoeff = 1;
    int damage;
    public Animator anim;
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject effect;
    Vector3 oldPosition;
    EnemyCreator enemyCreator;
    Environment environment;
    PauseMenu pauseMenu;
    WaveSetup waveSetup;
    bool igotcheckpoint;
    int pointId = -1;
    Rigidbody rb;
    bool died;
    
    private void Start()
    {
        oldPosition = transform.position;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.enabled = false;
        _currentHealthEnemy = enemyHp;
        enemyCreator = GameObject.Find("EnemyManager").GetComponent<EnemyCreator>();
        environment = GameObject.Find("EnvironmentManager").GetComponent<Environment>();
        pauseMenu = GameObject.Find("UIbundle").GetComponent<PauseMenu>();
        waveSetup = GameObject.Find("WaveManager").GetComponent<WaveSetup>();
        Init();
        SetCircuit();
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("AntiStuck", 3, 3f);
        InvokeRepeating("MakeDamage", damageTime, damageTime);
        effect.gameObject.SetActive(true);

    }

    public void MakeDamage()
    {
        environment.TotalHealth -= enemyDamage * pollutionCoeff;
        //print("TotalHealth " + environment.TotalHealth + " " + enemyDamage * pollutionCoeff);
    }

    void AntiStuck()
    {
        if ((transform.position - oldPosition).sqrMagnitude < 0.3f)
        {
            SetCircuit();
        }
        oldPosition = transform.position;
    }

    public void SetCircuit()
    {
        pointId = Random.Range(0, enemyCreator.bornPoint.Length);
        igotcheckpoint = true;
    }

    void FixedUpdate()
    {
        if (pointId != -1 && !died)
        {
            var distToPoint = Vector3.Distance(gameObject.transform.position, enemyCreator.bornPoint[pointId].transform.position);

            if (distToPoint <= 1f)
            {
                SetCircuit();
            }
            else if (distToPoint > 1f && igotcheckpoint && this.transform.position.y < 0.2f)
            {
                Move();
                igotcheckpoint = false;
            }

        }

    }

    public void Move()
    {
        agent.enabled = true;

        if (agent != null)
        {
            agent.destination = enemyCreator.bornPoint[pointId].transform.position;
            transform.LookAt(agent.destination);
            agent.speed = enemySpeed;
            anim.SetBool("goRun", true);
        }

        else
        {
            Debug.Log("No agent");
        }
    }


    public void Init()
    {
        anim = GetComponent<Animator>();
        if (anim == null)
        {
            print("Animator not found");
        }
    }

    public void GotDamage(int damage)
    {
        _currentHealthEnemy = Mathf.Max(_currentHealthEnemy - damage, 0);

        if (_currentHealthEnemy == 0)
        {
            KillEnemy();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Weapon")
        {
            damage = 5;
            GotDamage(damage);
            other.tag = "WeaponUsed";
            other.GetComponent<BoxCollider>().enabled = false;

        }
    }


    public void KillEnemy()
    {
        anim.SetBool("enemyDie", true);
        rb.AddForce(-transform.forward * 10f, ForceMode.Impulse);
        pauseMenu.killedEnemies += 1;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        Invoke("ReturnCollider", 0.1f);
        Destroy(gameObject, 10f);
        agent.speed = 0f;
        agent.enabled = false;
        enemyCreator.numberOfEnemies--;
        effect.gameObject.SetActive(false);
        pointId = -1;
        died = true;
        waveSetup.MinusEnemy();
    }

    void ReturnCollider()
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;
        //gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.2f, gameObject.transform.position.z);
    }

}
