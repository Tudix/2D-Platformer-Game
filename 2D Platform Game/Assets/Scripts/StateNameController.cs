using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateNameController : MonoBehaviour
{
    public static int IndexWaypoint;
    public static bool lookLeft;
    public static int AllCoins=0;
    public enum ControllerState {villager, archer, knight};
    public static ControllerState state = ControllerState.villager;
}
