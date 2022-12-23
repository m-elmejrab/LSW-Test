using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   [SerializeField] private Transform objectToFollow;
   [SerializeField] private bool isFollowingTarget;

   private void Update()
   {
      if (isFollowingTarget)
      {
         transform.position = new Vector3(objectToFollow.position.x, objectToFollow.position.y, transform.position.z);
      }
   }

   public void SetCameraToFollowTarget(bool follow)
   {
      if (follow)
      {
         isFollowingTarget = true;
      }
      else
      {
         isFollowingTarget = false;
      }
   }

   public void SetCameraTarget(Transform target)
   {
      objectToFollow = target;
   }
}
