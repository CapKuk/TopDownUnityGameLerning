using UnityEngine;

public class Collectable : Collideble
{
    protected bool collected = false;

    protected override void OnCollide(Collider2D collider)
    {
        if(collider.name == "Player")
        {
            OnCollect();
        }
    }

    protected virtual void OnCollect()
    {
        collected = true;
    }
}
