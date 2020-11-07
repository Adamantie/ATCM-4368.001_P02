using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAttackCard", menuName = "CardData/AttackCard")]
public class AttackCardData : ScriptableObject
{
    [SerializeField] string _name = "...";
    public string Name => _name;

    [SerializeField] int _damage = 5;
    public int Damage => _damage;

    [SerializeField] int _manaCost = 20;
    public int ManaCost => _manaCost;

    [SerializeField] Sprite _graphic = null;
    public Sprite Graphic => _graphic;

    [SerializeField] CardPlayEffect _playEffect = null;
    public CardPlayEffect PlayEffect => _playEffect;
}
