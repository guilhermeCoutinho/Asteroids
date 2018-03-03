using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player> , ILife {
    public float life;
    public float imunityAfterBeingHit;
    public GameObject gfx;
    int score;
    bool hasImunity;
    float timeTillImunityRunsOut;

    Rigidbody2D rb;

    void Awake () {
        rb= GetComponent<Rigidbody2D>();
    }

    void Start () {
        score = 0;
    }

    public int GetPlayerScore () {
        return score;
    }


    public void TakeDamage (int qtd) {
        if (hasImunity || !gameRunning())
            return;
        AudioManager.PlayOneShot(AudioManager.Instance.playerTakesDamage);
        rb.velocity = Vector3.zero;
        StartCoroutine(immunity());
        life -= qtd;
    }

    IEnumerator immunity()
    {
        hasImunity = true; 
        yield return null;
        rb.AddForce( -transform.up * 5, ForceMode2D.Impulse);
        for (int i = 0; i < imunityAfterBeingHit * 20; i++)
        {
            gfx.SetActive(!gfx.activeInHierarchy);
            yield return new WaitForSeconds(imunityAfterBeingHit / (imunityAfterBeingHit * 20));
        }
        gfx.SetActive(true);
        hasImunity = false;
    }

    public void Score (int amount) {
        if (!gameRunning())
            return;
        score += amount;
    }

    bool gameRunning () {
        return GameLoop.state == GameLoop.GameState.RUNNING;
    }
}
