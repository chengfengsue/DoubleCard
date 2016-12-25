using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CardItem : MonoBehaviour
{
    static public System.Action<CardItem> OnCardTurned;
    static public System.Action<CardItem> OnCardClick;
    [SerializeField] protected Animation Ani;
    [SerializeField] protected RectTransform InnerDisplay;
    [SerializeField] protected Text Text;
    [SerializeField] protected string InnerChar;

    public string Char{ get { return InnerChar; } }

    protected void OnEnable()
    {
        State = EState.Back;
        InnerDisplay.gameObject.SetActive(false);
        Text.text = InnerChar;
    }

    public EState State{ get; set; }

    public void OnScaleToZero()
    {
        var inner = InnerDisplay.gameObject.activeSelf;
        InnerDisplay.gameObject.SetActive(!inner);
    }

    public void OnScaleBack()
    {
        if(State != EState.Fixed)
        {
            Ani.Stop();
            State = InnerDisplay.gameObject.activeSelf ? EState.Front : EState.Back;
            if(OnCardTurned != null)
            {
                OnCardTurned.Invoke(this);
            }

        }
    }

    public void OnScaleStart()
    {
        State = EState.Turning;
    }

    public void OnClick()
    {
        if(State == EState.Back)
        {
            if(OnCardClick != null)
            {
                OnCardClick.Invoke(this);
            }
        }
    }

    public void SetState(EState state)
    {
        State = state;
        Refresh();
    }

    private void Refresh()
    {
        if (State == EState.Fixed || State == EState.Turning)
        {
            return;
        }
        if (Ani.isPlaying == false)
        {
            Ani.Play();
        }
    }
}

public enum EState
{
    Front,
    Back,
    Turning,
    Fixed,
}
