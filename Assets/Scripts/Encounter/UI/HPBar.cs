using System.Collections;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField] private GameObject health;

    public void SetHp(float value)
    {
        health.transform.localScale = new Vector3(value, 1f);
    }

    public IEnumerator ReduceHP(float updatedHP)
    {
        float currentHP = health.transform.localScale.x;
        float changeHP = currentHP - updatedHP;

        while (currentHP - updatedHP > Mathf.Epsilon)
        {
            currentHP -= changeHP * Time.deltaTime;
            health.transform.localScale = new Vector3(currentHP, 1f);
            yield return null;
        }
        health.transform.localScale = new Vector3(updatedHP, 1f);
    }
}
