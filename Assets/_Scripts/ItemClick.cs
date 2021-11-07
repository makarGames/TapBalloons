using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ItemClick : MonoBehaviour
{
    public System.Action OnClicked;

    private void OnMouseDown()
    {
        OnClicked?.Invoke();
    }
}
