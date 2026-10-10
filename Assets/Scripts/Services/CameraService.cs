using UnityEngine;

namespace BATTLE_TANKS
{
    public class CameraService : GenericSingleton<CameraService>
    {
        [SerializeField] private Camera cam;
        private bool cameraZoomOut;
        private float cameraSize;


        private void Start() 
        {
            cameraZoomOut = false;
            cameraSize = 15;
        }

        private void Update() 
        {
            if(cameraZoomOut)
            {
                cameraSize += 1.0f * Time.deltaTime;
                Camera.main.orthographicSize = cameraSize;
            }
        }

        public void StartFollowingPlayer(Transform playerTransform)
        {
            cam.transform.SetParent(playerTransform);
            //cam.transform.position = playerTransform.position;
        }

        public void StopFollowingPlayer()
        {
            cam.transform.SetParent(null);
        }

        public void SetCameraZoomOut(bool status)
        {
            cameraZoomOut = status;
        }

    }
}
