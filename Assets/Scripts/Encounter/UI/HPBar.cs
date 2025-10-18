using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField] private GameObject health;

    public void SetHp(float value)
    {
        health.transform.localScale = new Vector3(value, 1f);
    }
}
