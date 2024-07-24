using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;
    public DashSkill dash { get; private set;}
    public Clone_Skill clone_Skill { get; private set;}

    private void Awake() {
        if(instance!=null){
            Destroy(gameObject);
        }else{
            instance = this;
        }

    }

    private void Start() {
        dash = GetComponent<DashSkill>();
        clone_Skill = GetComponent<Clone_Skill>();
    }
}
