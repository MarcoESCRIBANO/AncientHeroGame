using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 20; 

    private float yaun = 0f;

    public Rigidbody​ rigidbodyPerso;

    private Animator animator;

    public List<string> animations;

    [SerializeField] private GameObject tourbiLolleEffect;
    [SerializeField] private GameObject coupEffect;
    [SerializeField] private GameObject shieldEffect;
    [SerializeField] private GameObject weaponObject;
    private GameObject shiedObject;
    bool hasShield = false;
    public static PlayerControl Instance { get; private set; }

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
    }

    void Update()
    {
        Move();

        Animation();

        rotation();
    }

    private void Move()
    {
        Vector3 deltaPosition = (transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical")) * Time.deltaTime * speed;
        deltaPosition.y = 0f;
        rigidbodyPerso.velocity = deltaPosition * 100 + new Vector3(0, rigidbodyPerso.velocity.y, 0);
    }

    private void Animation()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetTrigger("Attack");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetTrigger("Active");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            animator.SetTrigger("Passive");
        }

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        if (Mathf.Abs(h) > 0.001f)
            v = 0;

        var speed = Mathf.Max(Mathf.Abs(h), Mathf.Abs(v));
        animator.SetFloat("speedv", speed);
    }

    private void rotation()
    {
        yaun += Input.GetAxis("Mouse X");

        transform.eulerAngles = new Vector3(0f, yaun, 0f);
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

}
