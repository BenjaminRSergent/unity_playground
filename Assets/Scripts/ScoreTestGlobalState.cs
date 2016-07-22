using UnityEngine;
using System.Collections;

public class ScoreTestGlobalState : MonoBehaviour {
	public int maxLives = 3;
	public int maxHealth = 100;
	public int coinsPerLife = 100;
	private int _score;
	private int _lives;
	private int _coins;
	private int _health;

	public int Score {
		get {
			return _score;
		}

		private set {
			_score = value;

			_score = Mathf.Max (0, _score);
		}
	}
	public int Lives {
		get {
			return _lives;
		}

		private set {
			_lives = value;
			_lives = Mathf.Clamp (_lives, 0, maxLives);
		}
	}

	public int Health {
		get {
			return _health;
		}

		private set {
			_health = value;
			_health = Mathf.Clamp (_health, 0, maxHealth);

			if (_health == 0) {
				_health = maxHealth;
				RemoveLife ();
			}
		}
	}

	public int Coins {
		get {
			return _coins;
		}

		private set {
			_coins = value;
			_coins = Mathf.Max (0, _coins);
			if (_coins > coinsPerLife) {
				int toIncrease = _coins / coinsPerLife;
				_coins %= coinsPerLife;
				Lives += toIncrease;
			}
		}
	}


	public void AddPoints(int points) {
		Score += points;
	}
	public void RemovePoints(int points) {
		Score -= points;
	}

	public void AddLife() {
		Lives++;
	}
	public void RemoveLife() {
		Lives--;
	}
	public void AddCoins(int coins) {
		Coins += coins;
	}
	public void RemoveCoins(int coins) {
		Coins -= coins;
	}
	public void Heal(int amount) {
		Health += amount;
	}
	public void Damage(int amount) {
		Health -= amount;
	}



}
