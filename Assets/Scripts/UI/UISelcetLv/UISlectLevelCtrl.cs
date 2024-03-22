using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISlectLevelCtrl : BaseMonoBehaviour
{
    [SerializeField] protected Transform content;
    public Transform Content => content;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadContent();
    }
    protected virtual void LoadContent() {
        if (this.content != null) return;
        this.content = transform.Find("LvScrollView").Find("Viewport").Find("Content");
    }

}
