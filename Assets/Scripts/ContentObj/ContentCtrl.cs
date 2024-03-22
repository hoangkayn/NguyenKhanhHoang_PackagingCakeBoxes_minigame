using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentCtrl : BaseMonoBehaviour
{
    [SerializeField] protected List<Transform> slots;
    public List<Transform> Slots => slots;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSlots();
    }
    protected virtual void LoadSlots()
    {
        if (this.slots.Count > 0) return;

        foreach(Transform child in transform) {
            this.slots.Add(child);
        }

    }
}
