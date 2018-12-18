using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CardStack))]
public class CardStackView : MonoBehaviour
{
    CardStack deck;

    public Vector3 start;
    public float cardOffset;
    public GameObject cardPrefab;

    private void Start()
    {
        deck = GetComponent<CardStack>();
        ShowCards();
    }

    void ShowCards()
    {

        int cardCount = 0;


        foreach(int i in deck.GetCards())
        {

            float offset = cardOffset * cardCount;

            //copy card prefab
            GameObject cardCopy = (GameObject)Instantiate(cardPrefab);
            Vector3 temp = start + new Vector3(offset, 0f);
            cardCopy.transform.position = temp;


            //flip card over to show face
            CardModel cardModel = cardCopy.GetComponent<CardModel>();
            cardModel.cardIndex = i;
            cardModel.ToggleFace(true);

            //to sort which order to render the cards (to get the latest card behind the previous
            SpriteRenderer spriteRenderer = cardCopy.GetComponent<SpriteRenderer>();
            spriteRenderer.sortingOrder = cardCount; //51 -   to order it the other way

            cardCount++;
        }
    }

}
