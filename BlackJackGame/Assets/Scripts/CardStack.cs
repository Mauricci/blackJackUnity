using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardStack : MonoBehaviour 
{
	List<int> cards;


    //to access cards publicly
    public IEnumerable<int> GetCards()
    {
        foreach(int i in cards)
        {
            yield return i;
        }
    }

	public void Shuffle()
	{
		if (cards == null) {
			cards = new List<int> ();
		} 
		else
		{
			cards.Clear ();
		}

		for (int i = 0; i < 52; i++) 
		{
			cards.Add (i);
		}

		int num = cards.Count;
		while (num > 1) 
		{
			num--;
			int cardToChange = Random.Range (0, num + 1);
			int temp = cards [cardToChange];
			cards [cardToChange] = cards [num];
			cards [num] = temp;
		}
	}

	void Start () {
		Shuffle ();
	}
}
