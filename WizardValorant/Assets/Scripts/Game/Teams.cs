using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "My Assets/Teams")]
public class Teams : ScriptableObject
{
    public WizardManager[] Team;
    public bool attacking;
    public bool dead;
}
