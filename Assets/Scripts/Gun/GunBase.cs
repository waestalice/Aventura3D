using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
   public ProjectileBase prefabProjectile;

   public Transform positionToShoot;
   public float timeBetweenShoot = .3f;
   public float speed = 50f;

   private Coroutine _currentCoroutine;

   protected virtual IEnumerator ShootCoroutine()
   {
	   while(true)
	   {
		   Shoot();
		   yield return new WaitForSeconds(timeBetweenShoot);
	   }
   }

   public virtual void Shoot()
   {
	   if (prefabProjectile == null)
	   {
		   Debug.LogError("Prefab Projectile n�o atribu�do em GunBase.");
		   return;
	   }

	   if (positionToShoot == null)
	   {
		   Debug.LogError("Position to Shoot n�o atribu�do em GunBase.");
		   return;
	   }


	   var projectile = Instantiate(prefabProjectile);
	   projectile.transform.position = positionToShoot.position;
	   projectile.transform.rotation = positionToShoot.rotation;
	   projectile.speed = speed;

	   //ShakeCamera.Instance.Shake();
   }

   public void StartShoot()
   {
	   StopShoot();
	   _currentCoroutine = StartCoroutine(ShootCoroutine());
   }

   public void StopShoot()
   {
	   if(_currentCoroutine != null)
				StopCoroutine(_currentCoroutine);
   }
}
