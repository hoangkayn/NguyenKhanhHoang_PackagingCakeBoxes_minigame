using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenu : BaseMonoBehaviour
{
    private static UIMainMenu instance;
    public static UIMainMenu Instance => instance;
    [SerializeField] protected UIMainMenuCtrl uIMainMenuCtrl;
    public UIMainMenuCtrl UIMainMenuCtrl => uIMainMenuCtrl;
    protected override void Awake()
    {
        base.Awake();
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIMainMenuCtrl();
    }
    protected virtual void LoadUIMainMenuCtrl()
    {
        if (this.uIMainMenuCtrl != null) return ;
        this.uIMainMenuCtrl = transform.parent.GetComponent<UIMainMenuCtrl>();

    }
    protected virtual void Start()
    {
        PlayerPrefs.DeleteAll();    
    }
}
