using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UiController : MonoBehaviour {
    [SerializeField] protected GameObject Panel4;
    [SerializeField] protected GameObject Panel9;
    [SerializeField] protected Toggle Toggle4;
    [SerializeField] protected Toggle Toggle9;

    protected void OnEnable()
    {
        Panel4.gameObject.SetActive(true);
        Panel9.gameObject.SetActive(false);
        Toggle4.isOn = true;
        Toggle9.isOn = false;
    }

    public void OnToggleChanged()
    {
        Panel4.SetActive(Toggle4.isOn);
        Panel9.SetActive(Toggle9.isOn);
    }
}
