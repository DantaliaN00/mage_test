using JetBrains.Annotations;
using MageGame.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MageGame
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        MageGameController mageGameController;
        
        [CanBeNull]
        PlayerControls input;
        
        void Start()
        {
            input = new PlayerControls();
            
            input.Player.Move.Enable();
            
            input.Player.Rotation.Enable();
            
            input.Player.UseSkill.performed += UseSkillOnperformed;
            input.Player.UseSkill.Enable();
            
            input.Player.SwitchSkill.performed += SwitchSkillOnperformed;
            input.Player.SwitchSkill.Enable();
        }
        
        void Update()
        {
            if (input == null)
                return;
            
            if (mageGameController.Player == null)
                return;
            
            var moveScale = input.Player.Move.ReadValue<float>();
            var rotationScale = input.Player.Rotation.ReadValue<float>();
            
            var moveDirection = mageGameController.Player.transform.forward * moveScale;
            var rotationDirection = mageGameController.Player.transform.right * rotationScale;
            
            mageGameController.Player.Move(moveDirection);
            mageGameController.Player.Rotate(rotationDirection != Vector3.zero ? Quaternion.LookRotation(rotationDirection) : mageGameController.Player.transform.rotation);
        }
        
        void OnEnable()
        {
            input?.Player.Move.Enable();
            input?.Player.Rotation.Enable();
            input?.Player.UseSkill.Enable();
            input?.Player.SwitchSkill.Enable();
        }
        
        void OnDisable()
        {
            input?.Player.Move.Disable();
            input?.Player.Rotation.Disable();
            input?.Player.UseSkill.Disable();
            input?.Player.SwitchSkill.Disable();
        }
        
        void OnDestroy()
        {
            if (input == null)
                return;
            
            input.Player.UseSkill.performed -= UseSkillOnperformed;
            input.Player.SwitchSkill.performed -= SwitchSkillOnperformed;
        }
        
        void UseSkillOnperformed(InputAction.CallbackContext obj)
        {
            if (mageGameController.Player == null)
                return;
            
            mageGameController.Player.UseSkill();
        }
        
        void SwitchSkillOnperformed(InputAction.CallbackContext obj)
        {
            if (mageGameController.Player == null)
                return;
            
            var scale = obj.ReadValue<float>();
            
            if (scale > 0f)
                mageGameController.Player.NextSkill();
            else
                mageGameController.Player.PrevSkill();
        }
    }
}