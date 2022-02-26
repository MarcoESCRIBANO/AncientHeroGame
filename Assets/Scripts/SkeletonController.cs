using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour
{
    // Start is called before the first frame update
    private float distanceFromPerso;
    [SerializeField] GameObject notrePerso;
     //[SerializeField] GameObject skeletonObject;
    private Animator animator;
    private int health;
    private float rangeAttack = 15f;
    private float rangeTargetPlayer = 50f;
    private float speed = 0.1f;

    void Start()
    {
        animator = GetComponent<Animator>();
        this.health = 50;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(setAnimator());
    }
    private float calculeDistance()
    {
        Vector3 persoPos = notrePerso.transform.position;
        float dist = (persoPos- transform.position).sqrMagnitude;
        dist = Mathf.Sqrt(dist);
        //Debug.Log("calculeDistance" + dist + "alaed ");
        return dist;
    }
    IEnumerator setAnimator()
    {
        while (true)
        {
            animator.SetBool("isDead", this.health <= 0);
            animator.SetBool("canAttack", calculeDistance() < rangeAttack);
            if (calculeDistance() < rangeTargetPlayer)
            {
                if (!animator.GetBool("canAttack"))
                {

                    move();
                }
                animator.SetBool("playerDetected",true);
            }
            yield return new WaitForSeconds(.8f);
        }

    }
    private void move()
    {
        transform.position = Vector3.MoveTowards(transform.position, notrePerso.transform.position, speed * Time.deltaTime);
        Vector3 direction = notrePerso.transform.position - transform.position;
        direction.Normalize();
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.1f * Time.deltaTime);
    }
}
