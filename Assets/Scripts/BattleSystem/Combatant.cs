using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combatant : MonoBehaviour {

	public int speed = 10;
	public int health = 10;
	public int physAtk = 10;
	public int magAtk = 10;
	public int sharpDef = 10;
	public int bluntDef = 10;
	public int magDef = 10;

	public bool isEnemy = false;
	public string combatantName;

	void Awake () {
		if (!isEnemy) {
			for (int i = 0; i < BattleManager.battleManager.players.Length; i++) {
				if (!BattleManager.battleManager.players [i]) {
					BattleManager.battleManager.players[i] = this;
					i = BattleManager.battleManager.players.Length;
				}
			}
		}
	}
}
