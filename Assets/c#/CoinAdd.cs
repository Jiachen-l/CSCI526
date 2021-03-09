using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAdd : MonoBehaviour
{
	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.name == "XRpro") {
			ApplicationData.coins++;
			Destroy(this.gameObject);
		}
	}
}
