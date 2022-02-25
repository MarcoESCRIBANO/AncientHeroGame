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
        Debug.Log("calculeDistance" + dist + "alaed ");
        return dist;
    }
    IEnumerator setAnimator()
    {
        while (true)
        {
            animator.SetBool("isDead", this.health <= 0);
            animator.SetBool("canAttack", calculeDistance() < rangeAttack);
            animator.SetBool("playerDetected", calculeDistance() < rangeTargetPlayer);
            yield return new WaitForSeconds(.3f);
        }

    }
}
