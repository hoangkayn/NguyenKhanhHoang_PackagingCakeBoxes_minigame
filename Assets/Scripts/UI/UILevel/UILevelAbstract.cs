using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UILevelAbstract : BaseMonoBehaviour
{
    [SerializeField] protected UILevelCtrl uILevelCtrl;
    public UILevelCtrl UILevelCtrl => uILevelCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUILevelCtrl();
    }
    protected virtual void LoadUILevelCtrl()
    {
        if (this.uILevelCtrl != null) return;
        this.uILevelCtrl = transform.parent.GetComponent<UILevelCtrl>();
    }
}
