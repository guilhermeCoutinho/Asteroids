using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour , IPowerUp {
    float timeToDie;
    bool isActive = false;

    public void PowerUp(float duration)
    {
        timeToDie = Time.time + duration;
        isActive = true;
		Player.Instance.immunityBuffCount++;
        Player.Instance.GetComponent<ShieldGfx>().Show(true);
    }

    public void Deactivate()
    {
        Player.Instance.immunityBuffCount--;
        Player.Instance.GetComponent<ShieldGfx>().Show(false);
        Destroy(this);
    }

    void Update()
    {
        if (!isActive)
            return;
        if (Time.time >= timeToDie)
        {
            Deactivate();
        }
    }
	
}
