using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurplepotionController : MonoBehaviour
{
	public float EffectiveTime = 5f;

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.name == "XRpro") {
			PlayerController pc = other.gameObject.GetComponent<PlayerController>();
			pc.purplePotionEffective = EffectiveTime;
			Destroy(this.gameObject);
		}
	}
}
