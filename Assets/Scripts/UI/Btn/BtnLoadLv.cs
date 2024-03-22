using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BtnLoadLv : BaseBtnUIMenu
{
    protected override void OnClick()
    {
       this.uIMainMenuCtrl.UISelectLv.OnClickLevel(transform.parent.GetSiblingIndex());
    }
}
