using Game.CodeBase.Common.HealthSystem;
using Game.CodeBase.Weapon.Guns;
using TMPro;
using UnityEngine;

namespace Game.CodeBase.UI
{
   public class PlayerHud : MonoBehaviour
   {
      [SerializeField] private TextMeshProUGUI _healthText;
      [SerializeField] private TextMeshProUGUI _ammoText;
   
      private IHealth _health;
      private IGunView _gunView;
   
      public void Construct(IHealth health, IGunView gunView)
      {
         _health = health;
         _health.OnCurrentHealthChange += UpdateHealthInfo;
         _gunView = gunView;
         _gunView.OnGunInfoChange += UpdateAmmoInfo;
         UpdateHealthInfo();
         UpdateAmmoInfo(gunView);
      }

      public void DeInitialize()
      {
         _health.OnCurrentHealthChange -= UpdateHealthInfo;
         _gunView.OnGunInfoChange -= UpdateAmmoInfo;
      }

      private void UpdateHealthInfo()
      {
         _healthText.text = $"Health {_health.CurrentHealth}";
      }
   
      private void UpdateAmmoInfo(IGunView gunView)
      {
         _ammoText.text = $"Ammo {gunView.CurrentAmmo}";
      }
   }
}
