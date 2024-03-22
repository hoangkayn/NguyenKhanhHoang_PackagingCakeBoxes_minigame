using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UILevelCtrl : BaseMonoBehaviour
{
    [SerializeField] protected List<Image> stars;
    public List<Image> Stars => stars;
    [SerializeField] Sprite starYellow;
    public Sprite StarYellow => starYellow;
    [SerializeField] protected Transform uILose;
    public  Transform UILose => uILose;
    [SerializeField] protected Transform uIWin;
    public Transform UIWin => uIWin;
    
    [SerializeField] protected Timer timer;
    public Timer Timer => timer;
    [SerializeField] protected List<ObjectMovement> moveObjs;
    public List<ObjectMovement> MoveObjs => moveObjs;
    

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIWin();
        this.LoadUILose();
        this.LoadTimer();
        this.LoadStarYellow();
        this.LoadStars();
        this.LoadMoveObjs();
    }
    protected virtual void LoadMoveObjs()
    {
        if (this.moveObjs.Count > 0) return;
        Transform content = transform.Find("LevelView").Find("Viewport").Find("Content");
        ObjectMovement[] array = content.GetComponentsInChildren<ObjectMovement>();
        this.moveObjs.AddRange(array);
    }
    protected virtual void LoadStars()
    {
        if (this.stars.Count > 0) return;
        Transform starsObj = this.uIWin.Find("Stars");
        foreach(Transform child in starsObj)
        {
            this.stars.Add(child.GetComponent<Image>());    
        }
    }
    protected virtual void LoadStarYellow()
    {
        if (this.starYellow != null) return;
        this.starYellow = transform.Find("SpriteStarYellow").GetComponent<SpriteRenderer>().sprite;
    }
    protected virtual void LoadTimer()
    {
        if (this.timer != null) return;
        this.timer = transform.GetComponentInChildren<Timer>();
    }
    protected virtual void LoadUILose()
    {
        if (this.uILose != null) return;
        this.uILose = transform.Find("UILose");
    }
    protected virtual void LoadUIWin()
    {
        if (this.uIWin != null) return;
        this.uIWin = transform.Find("UIWin");
    }
    
   
}
