using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public CardStack player;
    public CardStack dealer;
    public CardStack deck;

    /*
     * Cards dealt to each player
     * First player hits/sticks/bust
     * Dealer's turn, must have minimum of 17 score hand before stick
     * Dealer cards: first card hidden, subsequent card are facing
     * 
     */

    #region Unity messages

    private void Start()
    {
        StartGame();
    }

    #endregion


    void StartGame()
    {
        for(int i = 0; i < 2; i++)
        {
            player.Push(deck.Pop());
            HitDealer();
        }
    }

    void HitDealer()
    {
        int card = deck.Pop();
        dealer.Push(card);

        if(dealer.CardCount >= 2)
        {
            CardStackView view = dealer.GetComponent<CardStackView>();
            view.Toggle(card, true);
        }
    }

}
