using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnExitUIInstruct : BaseBtnUIMenu
{
    protected override void OnClick()
    {
        this.uIMainMenuCtrl.UIInstruct.Close();
        this.uIMainMenuCtrl.UIFirst.Open();
    }
}
