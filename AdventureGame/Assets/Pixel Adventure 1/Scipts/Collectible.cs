using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int points;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public IEnumerator Collected()
    {
        anim.SetTrigger("Collected");
        GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
