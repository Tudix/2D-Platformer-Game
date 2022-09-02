using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{

    private Rigidbody2D rb;

    private Animator anim;
    public RuntimeAnimatorController Player;
    public RuntimeAnimatorController Player_Archer;
    public RuntimeAnimatorController Player_Sword;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!anim.GetBool("attacking"))
        {   
            // if(Input.GetKeyDown(KeyCode.Alpha1))
            // {      
            //     rb.bodyType = RigidbodyType2D.Dynamic;    
            //     anim.runtimeAnimatorController = Player as RuntimeAnimatorController;
            // }
            
            // if(Input.GetKeyDown(KeyCode.Alpha2))
            // {
            //     rb.bodyType = RigidbodyType2D.Dynamic;
            //     anim.runtimeAnimatorController = Player_Archer as RuntimeAnimatorController;
            // }   
            
            // if(Input.GetKeyDown(KeyCode.Alpha3))
            // {
            //     rb.bodyType = RigidbodyType2D.Dynamic;
            //     anim.runtimeAnimatorController = Player_Sword as RuntimeAnimatorController;
            // }   

            UpdateControllerState();
        }
    }

    private void UpdateControllerState()
    {
        //Debug.Log(StateNameController.state);

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {      
            StateNameController.state = StateNameController.ControllerState.villager;
        }
        
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            StateNameController.state = StateNameController.ControllerState.archer;
        }   
        
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            StateNameController.state = StateNameController.ControllerState.knight;
        }  

        if(Input.GetKeyDown(KeyCode.JoystickButton5))
        {      
            StateNameController.state = StateNameController.state+1;
            if (StateNameController.state > (StateNameController.ControllerState)2)
                StateNameController.state = (StateNameController.ControllerState)0;
        }

        if(Input.GetKeyDown(KeyCode.JoystickButton4))
        {      
            StateNameController.state = StateNameController.state-1;
            if (StateNameController.state < (StateNameController.ControllerState)0)
                StateNameController.state = (StateNameController.ControllerState)2;
        }

        switch(StateNameController.state) 
        {
            case StateNameController.ControllerState.villager:
                anim.runtimeAnimatorController = Player as RuntimeAnimatorController;
                break;
            case StateNameController.ControllerState.archer:
                anim.runtimeAnimatorController = Player_Archer as RuntimeAnimatorController;
                break;
            case StateNameController.ControllerState.knight:
            //case (StateNameController.ControllerState)2:
                anim.runtimeAnimatorController = Player_Sword as RuntimeAnimatorController;
                break;

        }

                
    }
}
