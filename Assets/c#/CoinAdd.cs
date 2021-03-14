using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAdd : MonoBehaviour
{
	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			ApplicationData.coins++;
			Destroy(this.gameObject);
		}
	}
}
