using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Singleton<Player> , ILife {
    public float life;
    public float imunityAfterBeingHit;
    public GameObject gfx;
    public Text lifeText;

    bool hasImunity;
    float timeTillImunityRunsOut;

    Rigidbody2D rb;

    void Awake () {
        rb= GetComponent<Rigidbody2D>();
    }

    void Start () {
        UpdateText ();
    }

    void UpdateText () {
        lifeText.text = "x" + life;
    }

    public void TakeDamage (int qtd) {
        if (hasImunity)
            return;
        rb.velocity = Vector3.zero;
        StartCoroutine(immunity());
        life -= qtd;
        UpdateText ();
    }

    IEnumerator immunity()
    {
        yield return null;
        rb.AddForce( -transform.up * 5, ForceMode2D.Impulse);
        hasImunity = true;
        for (int i = 0; i < imunityAfterBeingHit * 20; i++)
        {
            gfx.SetActive(!gfx.activeInHierarchy);
            yield return new WaitForSeconds(imunityAfterBeingHit / (imunityAfterBeingHit * 20));
        }
        gfx.SetActive(true);
        hasImunity = false;
    }
}
