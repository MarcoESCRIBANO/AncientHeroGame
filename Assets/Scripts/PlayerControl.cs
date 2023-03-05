using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public float speed = 15; 

    private float yaun = 180f;

    public Rigidbody​ rigidbodyPerso;

    private Animator animator;

    public List<string> animations;

    [SerializeField] private GameObject tourbiLolleEffect;
    [SerializeField] private GameObject coupEffect;
    [SerializeField] private GameObject shieldEffect;
    [SerializeField] private GameObject weaponObject;
    [SerializeField] private GameObject HealthObject;
    private GameObject shiedObject;
    bool hasShield = false;
    public static PlayerControl Instance { get; private set; }

    private PlayerInput playerInput;
    float h;
    float v;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
    }

    void Start()
    {
        rigidbodyPerso = GetComponent<Rigidbody>();

        animator = GetComponent<Animator>();
        animations = new List<string>()
        {
            "Attack",
            "Active",
            "Passive"
        };

        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        //Move();

        Animation();

        //rotation();
        isDead();
        hasWon();
    }



    private void Animation()
    {
        //if (playerInput.actions["AttackDeBase"].)
        //{
        //    animator.SetTrigger("Attack");
        //}
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    animator.SetTrigger("Active");
        //}
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    animator.SetTrigger("Passive");
        //}
        //if (Input.GetKeyDown(KeyCode.Tab))
        //{
        //    SceneManager.LoadScene("UIScene");
        //}

        h = playerInput.actions["Move"].ReadValue<Vector2>().x;
        v = playerInput.actions["Move"].ReadValue<Vector2>().y;

        if (Mathf.Abs(h) > 0.001f)
            v = 0;

        var speed = Mathf.Max(Mathf.Abs(h), Mathf.Abs(v));
        animator.SetFloat("speedv", speed);
    }

    public void OnMove()
    {
        Debug.Log("Test");
        Vector3 deltaPosition = (transform.right * playerInput.actions["Move"].ReadValue<Vector2>().x + transform.forward * playerInput.actions["Move"].ReadValue<Vector2>().y) * Time.deltaTime * speed;
        deltaPosition.y = 0f;
        rigidbodyPerso.velocity = deltaPosition * 100 + new Vector3(0, rigidbodyPerso.velocity.y, 0);
    }

    public void OnAttackDeBase()
    {
        animator.SetTrigger("Attack");
    }

    public void OnShield()
    {
        animator.SetTrigger("Active");
    }

    public void OnAttackUltime()
    {
        animator.SetTrigger("Passive");
    }

    public void OnMenu()
    {
        SceneManager.LoadScene("UIScene");
    }


    private void rotation()
    {
        //yaun += playerInput.actions["CameraMove"].ReadValue<Vector2>().x;

        transform.eulerAngles = new Vector3(0f, yaun, 0f);
    }
    private void isDead()
    {
        if (HealthObject.GetComponent<HealtBarHandler>().getHealth() < 0)
        {
            SceneManager.LoadScene("UIScene");
        }
    }
    public void setParticuleAttack()
    {
        GameObject effect = Instantiate(coupEffect, weaponObject.transform);
        ParticleSystem.MainModule particle = effect.GetComponent<ParticleSystem>().main;
        Destroy(effect, particle.duration);
    }
    public void setParticuleActive()
    {
        if (hasShield == false)
        {
            shiedObject = Instantiate(shieldEffect, this.transform);
            hasShield = true;
            StartCoroutine(nameof(TimeShield));
        }
    }
    public void setParticulePassive()
    {
        GameObject effect = Instantiate(tourbiLolleEffect, weaponObject.transform);
        ParticleSystem.MainModule particle = effect.GetComponent<ParticleSystem>().main;
        Destroy(effect, particle.duration);
    }
    public void setShieldOff()
    {

        if(hasShield == true)
        {
            Destroy(shiedObject);
            hasShield = false;
        }
        
    }
    private void hasWon()
    {
        if (GameObject.FindGameObjectsWithTag("Ennemy").Length == 0)
        {
            SceneManager.LoadScene("WinningScene");
        }
    }

    IEnumerator TimeShield()
    {
        yield return new WaitForSeconds(10f);
        setShieldOff();
    }

}
