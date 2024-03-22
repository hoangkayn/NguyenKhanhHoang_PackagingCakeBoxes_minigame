using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnOpenInstruct : BaseBtnUIMenu
{
    protected override void OnClick()
    {
        this.uIMainMenuCtrl.UIFirst.Close();
        this.uIMainMenuCtrl.UIInstruct.Open();
       
    }
}
