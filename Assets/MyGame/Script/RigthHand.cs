using System.Runtime.CompilerServices;
using UnityEngine;

public class RigthHand : MonoBehaviour
{



    private Animator anim;
    private int j_anim;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        j_anim = Animator.StringToHash("j_anim");
    }

    void Update()
    {
      if(Input.GetKeyDown(KeyCode.J))
        {
            anim.SetTrigger(j_anim);
        }
    }
}
