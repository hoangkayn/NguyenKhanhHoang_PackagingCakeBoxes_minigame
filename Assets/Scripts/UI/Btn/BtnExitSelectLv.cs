using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnExitSelectLv : BaseBtnUIMenu
{
    protected override void OnClick()
    {
        this.uIMainMenuCtrl.UISelectLv.Close();
        this.uIMainMenuCtrl.UIFirst.Open();
    }
}
