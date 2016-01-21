using KGCustom.Controller;
using UnityEngine;

namespace KGCustom.Model
{
    public class DamageDead : PlayerBehavior<DamageDead>
    {
        public override void begin(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            pc.transform.parent.Find("Collider/HitCollider").gameObject.SetActive(false);
            Time.timeScale = 0.5f;
            pc.audioSource.pitch = 0.5f;
        }

        public override void end(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            Time.timeScale = 1.0f;
            pc.audioSource.pitch = 1.0f;
            UIDeadCountdown.Instance.WindowOpen();
            //GameController.Instance.Reset();
        }
    }
}
