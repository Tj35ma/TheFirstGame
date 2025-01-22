using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : TFGMonoBehaviour
{
    [SerializeField] protected List<Point> points;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoints();
    }

    public virtual void LoadPoints()
    {

        if (this.points.Count > 0) return;
        foreach (Transform child in transform)
        {
            Point points = child.GetComponent<Point>();
            points.LoadNextPoint();
            this.points.Add(points);
        }
        Debug.Log(transform.name + ": LoadPoints", gameObject);
    }

    public virtual Point GetPoint(int index)
    {
        return this.points[index];
    }
}
