using UnityEngine;

public class BulletCtrl : PoolObj
{
    [SerializeField] protected float speed = 50f;
    

    public override string GetName()
    {
        return "Bullet";
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }    
}
