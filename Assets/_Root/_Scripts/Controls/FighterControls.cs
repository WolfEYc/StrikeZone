using UnityEngine;
using UnityEngine.InputSystem;

namespace Strikezone
{
    [RequireComponent(typeof(Animator), typeof(Facing), typeof(Movement))]
    public class FighterControls : MonoBehaviour
    {
        Animator _animator;
        Facing _facing;
        Movement _movement;

        public static readonly int StunnedID = Animator.StringToHash("stunned");

        public static readonly int HorizontalControlAsFloatID = Animator.StringToHash("horizontal_control_asfloat");
        public static readonly int HorizontalControlID = Animator.StringToHash("horizontal_control");
        public static readonly int VerticalControlID = Animator.StringToHash("vertical_control");
        
        public static readonly int JumpPressedControlID = Animator.StringToHash("jump_pressed_control");
        public static readonly int JumpHeldID = Animator.StringToHash("jump_held");

        public static readonly int DodgeControlID = Animator.StringToHash("dodge_pressed_control");
        
        public static readonly int AttackPressedControlID = Animator.StringToHash("attack_pressed_control");
        public static readonly int AttackHeldID = Animator.StringToHash("attack_held");
        
        public static readonly int LightAttackPressedControlID = Animator.StringToHash("light_attack_pressed_control");
        public static readonly int HeavyAttackPressedControlID = Animator.StringToHash("heavy_attack_pressed_control");
        public static readonly int SpecialPressedControlID = Animator.StringToHash("special_attack_pressed_control");
        
        
        const float Threshold = 0.5f;
        const float RunThreshold = 0.8f;
        
        Vector2Int _prevMoveCtrls;

        public Vector2 MoveCtrls { get; private set; }
        
        void Awake()
        {
            _animator = GetComponent<Animator>();
            _facing = GetComponent<Facing>();
            _movement = GetComponent<Movement>();
        }

        public bool Stunned => _animator.GetBool(StunnedID);

        public void SetStunned(bool stunned)
        {
            _animator.SetBool(StunnedID, stunned);
        }

        public void SetMoveControls(InputAction.CallbackContext ctx)
        {
            MoveCtrls = ctx.action.ReadValue<Vector2>();
            SetHorizontalControl(MoveCtrls.x);
            SetVerticalControl(MoveCtrls.y);
        }

        int GetHorizontalIntFromFloat(float f)
        {
            return f switch
            {
                < -RunThreshold => -2,
                < -Threshold => -1,
                < Threshold => 0,
                < RunThreshold => 1,
                _ => 2
            };
        }

        int GetVerticalControlFromFloat(float f)
        {
            return f switch
            {
                < -Threshold => -1,
                < Threshold => 0,
                _ => 1
            };
        }

        void SetHorizontalControl(float fhorizontalControl)
        {
            int horizontalControl = GetHorizontalIntFromFloat(fhorizontalControl);
            
            if(horizontalControl == _prevMoveCtrls.x) return;
            _prevMoveCtrls.x = horizontalControl;

            _movement.SetControlState(horizontalControl);
            
            _animator.SetInteger(HorizontalControlID, horizontalControl);
            _animator.SetFloat(HorizontalControlAsFloatID, horizontalControl);
            
            if(Stunned || horizontalControl == 0) return;

            _facing.SetFacing(horizontalControl > 0);
        }

        void SetVerticalControl(float fverticalControl)
        {
            int verticalControl = GetVerticalControlFromFloat(fverticalControl);
            
            if(verticalControl == _prevMoveCtrls.y) return;
            _prevMoveCtrls.y = verticalControl;

            _animator.SetInteger(VerticalControlID, verticalControl);
        }

        public void SetJumpControl(InputAction.CallbackContext ctx)
        {
            if(Stunned) return;
            bool pressed = ctx.action.IsPressed();
            
            _animator.SetBool(JumpHeldID, pressed);
            
            if(!pressed) return;
            
            _animator.SetTrigger(JumpPressedControlID);
                  
        }

        public void SetLightAttackControl(InputAction.CallbackContext ctx)
        {
            SetAttackControl(LightAttackPressedControlID, ctx.action.IsPressed());
        }

        public void SetHeavyAttackControl(InputAction.CallbackContext ctx)
        {
            SetAttackControl(HeavyAttackPressedControlID, ctx.action.IsPressed());
        }
        
        public void SetSpecialAttackControl(InputAction.CallbackContext ctx)
        {
            SetAttackControl(SpecialPressedControlID, ctx.action.IsPressed());
        }

        public void SetDodgeControl(InputAction.CallbackContext ctx)
        {
            if(Stunned || !ctx.action.IsPressed()) return;
            _animator.SetTrigger(DodgeControlID);
        }

        void SetAttackControl(int attackCntrl, bool isPressed)
        {
            if(Stunned) return;
            
            _animator.SetBool(AttackHeldID, isPressed);
            
            if(!isPressed) return;
            
            _animator.SetTrigger(AttackPressedControlID);
            _animator.SetTrigger(attackCntrl);
                    
        }

    }
}
