using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager {

	Combatant[] players;
	Combatant[] enemies;

	public TurnManager (Combatant[] _players, Combatant[] _enemies) {
		players = _players;
		enemies = _enemies;
	}
}
