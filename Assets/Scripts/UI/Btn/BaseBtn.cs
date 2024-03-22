using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseBtn : BaseMonoBehaviour
{
    [SerializeField] protected Button button;
    

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadButton();
       
    }
   
    protected virtual void Start()
    {
        this.OnListen();
    }
    protected virtual void LoadButton()
    {
        if (this.button != null) return;
        this.button = transform.GetComponent<Button>();
    }
    protected virtual void OnListen()
    {
        button.onClick.AddListener(OnClick);
    }
    protected abstract void OnClick();
}
