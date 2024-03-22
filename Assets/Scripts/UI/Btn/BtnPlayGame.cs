using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnPlayGame : BaseBtnUIMenu
{
    protected override void OnClick()
    {
        this.uIMainMenuCtrl.UIFirst.Close();
        this.uIMainMenuCtrl.UISelectLv.Open();
      
        
    }
}
   
