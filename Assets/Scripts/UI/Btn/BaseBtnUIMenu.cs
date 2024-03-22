using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBtnUIMenu : BaseBtn
{
    [SerializeField] protected UIMainMenuCtrl uIMainMenuCtrl;
    public UIMainMenuCtrl UIMainMenuCtrl => uIMainMenuCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIMainMenuCtrl();
    }
    protected virtual void LoadUIMainMenuCtrl()
    {
        if (this.uIMainMenuCtrl != null) return;
        this.uIMainMenuCtrl = transform.parent.parent.GetComponent<UIMainMenuCtrl>() ;
    }

    protected override void OnClick()
    {
       
    }
}
