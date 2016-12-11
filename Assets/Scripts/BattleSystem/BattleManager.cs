using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BattleManager : MonoBehaviour {

	public delegate void BattleStart();
	public delegate void BattleWon();
	public delegate void BattleLost();
	public static event BattleStart OnStart;
	public static event BattleWon OnWon;
	public static event BattleLost OnLost;

	[SerializeField] private int maxPlayers;
	[SerializeField] private int maxEnemies;

	public Combatant[] players;
	public Combatant[] enemies;

	public enum StatusEffect {
		Bleeding,
		Stunned,
		Burned,
		Slowed
	};

	StatusEffect[] playerEffects;
	StatusEffect[] enemyEffects;

	public static BattleManager battleManager;
	public static TurnManager turnManager;


	void Awake () {
		players = new Combatant[maxPlayers];
		enemies = new Combatant[maxEnemies];
		battleManager = this;
		turnManager = new TurnManager(players, enemies);
	}
}
