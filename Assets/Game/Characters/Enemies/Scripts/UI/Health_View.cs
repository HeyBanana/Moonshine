using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health_View : MonoBehaviour
{
    [SerializeField] private Health _heatlth;
    [SerializeField] private Image _progressBar;
    [SerializeField] private TextMeshProUGUI _healthCount;
    private void Start()
    {
       // heatlth = gameObject.GetComponent<Health>();
        _healthCount.text = _heatlth.CurrentHeath.ToString();
        _heatlth.OnDamaged += OnHealthChanged;
    }
    private void OnHealthChanged(int current, int max)
    {
        _healthCount.text = current.ToString();
        SetFill((float)current / (float)max);
    }
    private void SetFill(float fillAmount)
    {
        _progressBar.fillAmount = fillAmount;
    }

}
