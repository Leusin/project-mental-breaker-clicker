using UnityEngine;

public class CGClickButton : MonoBehaviour
{
    public Animator anim;
    public void OnMouseDown()
    {
        CGDataController.Instance.Point += CGDataController.Instance.PerClick;

        anim.SetTrigger("OnClick");
    }
}
