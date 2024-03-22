using TMPro;
using UnityEngine;

public class Timer : BaseMonoBehaviour
{

    [SerializeField] protected TextMeshProUGUI text;
    [SerializeField] protected float remainingTime = 45f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadText();
    }
    protected virtual void LoadText()
    {
        if (this.text != null) return;
        this.text = transform.GetComponentInChildren<TextMeshProUGUI>();
    }
    protected virtual void FixedUpdate()
    {
        this.Timing();
    }
    protected virtual void Timing()
    {
        this.remainingTime -= Time.fixedDeltaTime;
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        this.CheckGameOver(seconds);
        this.CheckFormat(seconds);
        this.CheckStar(seconds);
        
        
        

    }
    protected virtual void CheckGameOver(int seconds)
    {
        if (seconds > 0) return;
           UILevel.Instance.GameOver();
    }
    protected virtual void CheckFormat(int seconds)
    {
        if (seconds < 10)
        {
            text.text = string.Format("00:0{0}", seconds);
        }
        else
        {
            text.text = string.Format("00:{00}", seconds);
        }
    }
    protected virtual void CheckStar(int seconds)
    {
        if(30 <= seconds && seconds < 45)
        {
            UILevel.Instance.SetStarCount(3);
        }
        if(15 <= seconds && seconds < 30)
        {
            UILevel.Instance.SetStarCount(2);
        }
        if(0 < seconds && seconds < 15)
        {
            UILevel.Instance.SetStarCount(1);
        }
        if(seconds == 0) {
            UILevel.Instance.SetStarCount(0);
        }

    }
}