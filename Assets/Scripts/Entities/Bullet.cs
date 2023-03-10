using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PoolElement
{
	//static properties
	public static string Tag = "Bullet";

	//public/inspector properties
	[SerializeField] private float speed;

	//unity methods
	void Update()
	{
		if (GameManager.Instance.GamePaused)
		{
			return;
		}
		transform.position += Vector3.right * speed;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (!gameObject.activeSelf)
		{
			return;
		}
		if (other.CompareTag(GameManager.BarrierTag))
		{
			PoolManager.BulletPool.Release(this);
		}
		if (other.CompareTag(Enemy.Tag))
		{
			PoolManager.BulletPool.Release(this);
		}
	}

	//public methods

	public override void Init()
	{
		throw new System.NotImplementedException();
	}

	public void Shot(Vector3 startPosition)
	{
		transform.position = startPosition;
	}

    public override void Return()
    {
        if(gameObject.activeSelf)
        {
            PoolManager.BulletPool.Release(this);
        }
    }

}
