using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityCardView : MonoBehaviour
{
    [SerializeField] TMP_Text _nameTextUI = null;
    [SerializeField] TMP_Text _costTextUI = null;
    [SerializeField] Image _graphicUI = null;

    public void Display(AbilityCard abilityCard)
    {
        _nameTextUI.text = abilityCard.Name;
        _costTextUI.text = abilityCard.Cost.ToString();
        _graphicUI.sprite = abilityCard.Graphic;
    }
}
