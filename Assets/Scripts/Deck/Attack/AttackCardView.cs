using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AttackCardView : MonoBehaviour
{
    [SerializeField] TMP_Text _nameTextUI = null;
    [SerializeField] TMP_Text _damageTextUI = null;
    [SerializeField] TMP_Text _manaCostTextUI = null;
    [SerializeField] Image _graphicUI = null;

    public void Display(AttackCard attackCard)
    {
        _nameTextUI.text = attackCard.Name;
        _damageTextUI.text = attackCard.Damage.ToString();
        _manaCostTextUI.text = attackCard.ManaCost.ToString();
        _graphicUI.sprite = attackCard.Graphic;
    }
}
