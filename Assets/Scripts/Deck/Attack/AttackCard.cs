using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCard : Card
{
    public int Damage { get; private set; }
    public int ManaCost { get; private set; }
    public Sprite Graphic { get; private set; }
    public CardPlayEffect PlayEffect { get; private set; }

    public AttackCard(AttackCardData Data)
    {
        Name = Data.Name;
        Damage = Data.Damage;
        ManaCost = Data.ManaCost;
        Graphic = Data.Graphic;
        PlayEffect = Data.PlayEffect;
    }

    public override void Play()
    {
        ITargetable target = TargetController.CurrentTarget;
        Debug.Log("Playing " + Name + " on target.");
        PlayEffect.Activate(target);
    }
}
