using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenuCtrl : BaseMonoBehaviour
{
   
    [SerializeField] protected UIInstruct uIInstruct;
    public UIInstruct UIInstruct => uIInstruct;
    [SerializeField] protected UISelectLv uISelectLv;
    public UISelectLv UISelectLv => uISelectLv;
    [SerializeField] protected UIFirst uIFirst;
    public UIFirst UIFirst => uIFirst;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIInstruct();
        this.LoadUISelectLv();
        this.LoadUIFirst();
    }
    protected virtual void LoadUIInstruct()
    {
        if (this.uIInstruct != null) return;
        this.uIInstruct = transform.Find("UIInstruct").GetComponent<UIInstruct>();
    }
    protected virtual void LoadUISelectLv()
    {
        if (this.uISelectLv != null) return;
        this.uISelectLv = transform.Find("UISelectLevel").GetComponent<UISelectLv>();
    }
    protected virtual void LoadUIFirst()
    {
        if (this.uIFirst != null) return;
        this.uIFirst = transform.Find("UIFirst").GetComponent<UIFirst>();
    }
}
