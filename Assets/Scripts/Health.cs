using UnityEngine;

public class Health : MonoBehaviour {
	public float initialHealth;

	float health;

	void Start() {
		health = initialHealth;
	}

	//Damages this character. Meant to be called through a SendMessage()
	public void Damage(float amount) {
		health -= amount;
	}

	//Heals this character. Meant to be called through a SendMessage()
	public void Heal(float amount) {
		health += amount;
	}
	//Gets the health of this character. Meant to be called through a SendMessage()
	public float GetHealth() {
		return health;
	}
}
