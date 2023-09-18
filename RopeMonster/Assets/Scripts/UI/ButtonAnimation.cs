using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    Animation buttonAnimation_click;
    

    void Awake()
    {
        buttonAnimation_click = GetComponent<Animation>();
    }

    public void PlayAnimation_Click()
    {
        buttonAnimation_click.Play();
    }
}
