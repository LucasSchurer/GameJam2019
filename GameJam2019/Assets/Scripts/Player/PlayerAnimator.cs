using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private PlayerInfo playerInfo;
    private Animator anim;

    void Start()
    {
        playerInfo = GetComponentInParent<PlayerInfo>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        anim.SetBool("isIdle", playerInfo.isIdle);
        anim.SetBool("isRunning", playerInfo.isRunning);
        anim.SetBool("isJumping", playerInfo.isJumping);
        anim.SetBool("isFalling", playerInfo.isFalling);
        anim.SetBool("isInMadnessDimension", playerInfo.isInMadnessDimension);
    }
}
