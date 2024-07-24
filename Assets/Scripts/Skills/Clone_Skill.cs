using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone_Skill : Skill
{
    [SerializeField] private GameObject cloneRefab;

    public void CreateClone(){
        GameObject newClone = Instantiate(cloneRefab);
    }
    public override void UseSkill(){
        base.UseSkill();
        Debug.Log("Leave Clone behind");
    }
}
