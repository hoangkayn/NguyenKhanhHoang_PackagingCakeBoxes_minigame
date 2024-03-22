using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelObj : BaseMonoBehaviour
{
    [SerializeField] protected Button button;
    public Button Button => button;
    [SerializeField] protected List<Image> stars;
    public List<Image> Stars => stars;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadStars();
        this.LoadButton();
    }
    protected virtual void LoadButton()
    {
        if (this.button != null) return;
        this.button = transform.GetComponentInChildren<Button>();
    }
    protected virtual void LoadStars()
    {
        if (this.stars.Count > 0) return;
        Transform starsObj = transform.Find("Stars");
        Image[] array = starsObj.GetComponentsInChildren<Image>();
        this.stars.AddRange(array);
    }
}
