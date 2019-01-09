using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDealer : MonoBehaviour {

    public CardStack dealer;
    public CardStack player;

//    Debug test code to test hand value
//    int count = 0;
//    int[] cards = new int[] { 9, 7, 12 };

    private void OnGUI()
    {
        if(GUI.Button(new Rect(10, 10, 256, 28), "Hit me!" ))
        {
            player.Push(dealer.Pop());
        }

//        if (GUI.Button(new Rect(10, 10, 256, 28), "Hit me!"))
//        {
//            player.Push(cards[count++]);
//        }
    }
}
