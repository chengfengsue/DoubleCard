using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
    [SerializeField] protected CardItem[] Cards;

    protected void OnEnable()
    {
        CardItem.OnCardTurned += OnCardTurned;
        CardItem.OnCardClick += OnCardClick;
    }
    protected void OnDisable()
    {
        CardItem.OnCardTurned -= OnCardTurned;
        CardItem.OnCardClick -= OnCardClick;
    }

    private void OnCardTurned(CardItem card)
    {
        foreach(var item in Cards)
        {
            if(item.State == EState.Front && item != card )
            {
                if(item.Char == card.Char)
                {
                    item.SetState(EState.Fixed);
                    card.SetState(EState.Fixed);
                }
                else
                {
                    card.SetState(EState.Back);
                    item.SetState(EState.Back);
                }
            }
        }

    }

    private void OnCardClick(CardItem card)
    {
        foreach(var item in Cards)
        {
            if(item.State == EState.Turning)
            {
                return;
            }
        }
        card.SetState(EState.Back);
    }
}           
