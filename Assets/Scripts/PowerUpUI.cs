using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpUI : MonoBehaviour {

	public GameObject powerUpIndicatorAdapter;
	public GameObject powerUpIndicatorUIHolder;

	public void StartPowerUp (float duration, Sprite sprite){
		GameObject indicator = Instantiate(powerUpIndicatorAdapter,
			powerUpIndicatorUIHolder.transform);
        Image background = indicator.GetComponent<Image>();
    	Image overlay = indicator.transform.GetChild(0).GetComponent<Image>();
		background.sprite = sprite;
		overlay.sprite = sprite;
        background.gameObject.SetActive(true);
        overlay.gameObject.SetActive(true);
		StartCoroutine(countDown(duration,indicator,overlay));
	}

	IEnumerator countDown (float time , GameObject indicator, Image overlay) {
		float timeEllapsed = 0;
        overlay.fillAmount = 0;

		while (timeEllapsed <= time) {
			yield return null;
            timeEllapsed += Time.deltaTime;
			overlay.fillAmount = timeEllapsed / time;
		}
		Destroy(indicator);
	}

}
