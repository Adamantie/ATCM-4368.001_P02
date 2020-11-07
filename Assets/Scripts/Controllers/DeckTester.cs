using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckTester : MonoBehaviour
{
    [SerializeField] List<AttackCardData> _attackDeckConfig = new List<AttackCardData>();
    [SerializeField] AttackCardView _attackCardView = null;

    [SerializeField] Image _attackDeckGraphic = null;
    [SerializeField] GameObject _attackDiscardGraphic = null;
    [SerializeField] GameObject _attackPlayerGraphic = null;

    Deck<AttackCard> _attackDeck = new Deck<AttackCard>();
    Deck<AttackCard> _attackDiscard = new Deck<AttackCard>();

    Deck<AttackCard> _playerHand = new Deck<AttackCard>();

    private void Start()
    {
        SetupAttackDeck();
    }

    private void SetupAttackDeck()
    {
        foreach(AttackCardData attackData in _attackDeckConfig)
        {
            AttackCard newAttackCard = new AttackCard(attackData);
            _attackDeck.Add(newAttackCard);
        }

        _attackDeck.Shuffle();

        Draw();
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Q))
        {
            Draw();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            PrintPlayerHand();
        }*/
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayTopCard();
        }
    }

    private void Draw()
    {
        AttackCard newCard = _attackDeck.Draw(DeckPosition.Top);
        Debug.Log("Drew card: " + newCard.Name);
        _playerHand.Add(newCard, DeckPosition.Top);

        _attackCardView.Display(newCard);

        if (_attackDeck.Count == 0)
        {
            _attackDeckGraphic.enabled = false;
        }
        else
        {
            _attackDeckGraphic.enabled = true;
        }

        print(_attackDeck.Count);
        print(_attackDiscard.Count);
    }

    private void PrintPlayerHand()
    {
        for (int i = 0; i < _playerHand.Count; i++)
        {
            Debug.Log("Player Hand Card: " + _playerHand.GetCard(i).Name);
        }
    }

    void PlayTopCard()
    {
        AttackCard targetCard = _playerHand.TopItem;
        targetCard.Play();
        //TODO consider expanding Remove to accept a deck position
        _playerHand.Remove(_playerHand.LastIndex);
        _attackDiscard.Add(targetCard);
        Debug.Log("Card added to discard: " + targetCard.Name);

        if (_attackDiscard.Count > 0)
        {
            _attackDiscardGraphic.SetActive(true);
        }
        if (_attackDiscard.Count == 10)
        {
            SetupAttackDeck();
            _attackDiscardGraphic.SetActive(false);
        }

        Draw();
    }
}
