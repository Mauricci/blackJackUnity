using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CardStack))]
public class CardStackView : MonoBehaviour
{
    CardStack deck;
    Dictionary<int, GameObject> fetchedCards;
    int lastCount;

    public Vector3 start;
    public float cardOffset;
    public bool faceUp = false;
    public GameObject cardPrefab;

    private void Start()
    {
        fetchedCards = new Dictionary<int, GameObject>();
        deck = GetComponent<CardStack>();
        ShowCards();
        lastCount = lastCount - deck.CardCount;

        deck.CardRemoved += deck_CardRemoved;
    }

    private void deck_CardRemoved(object sender, CardRemovedEventArgs e)
    {
        if(fetchedCards.ContainsKey(e.CardIndex))
        {
            Destroy(fetchedCards[e.CardIndex]);
            fetchedCards.Remove(e.CardIndex);
        }
    }

    private void Update()
    {
        if(lastCount != deck.CardCount)
        {
            lastCount = lastCount - deck.CardCount;
            ShowCards();
        }
    }

    void ShowCards()
    {

        int cardCount = 0;              //position in hand

        if (deck.HasCards)
        {

            foreach (int i in deck.GetCards())              //GetCards = position in deck
            {
                float offset = cardOffset * cardCount;
                Vector3 temp = start + new Vector3(offset, 0f);
                AddCard(temp, i, cardCount);
                cardCount++;
            }
        }
    }

    void AddCard(Vector3 position, int cardIndex, int positionIndex)
    {
        if(fetchedCards.ContainsKey(cardIndex))
        {
            return;
        }

        GameObject cardCopy = (GameObject)Instantiate(cardPrefab);
        cardCopy.transform.position = position;


        //flip card over to show face
        CardModel cardModel = cardCopy.GetComponent<CardModel>();
        cardModel.cardIndex = cardIndex;
        cardModel.ToggleFace(faceUp);

        //to sort which order to render the cards (to get the latest card behind the previous
        SpriteRenderer spriteRenderer = cardCopy.GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = positionIndex; //51 - positionInedex  to order it the other way

        fetchedCards.Add(cardIndex, cardCopy);
    }

}
