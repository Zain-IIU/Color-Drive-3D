using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Multiplier : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private int multiplyValue;
    [SerializeField] private TextMeshPro multiplierText;
    [SerializeField] private Color[] randomColor;
    
    private void Start()
    {
        meshRenderer.material.color = randomColor[Random.Range(0, randomColor.Length)];
    }

    public int GetMultiplierValue() => multiplyValue;
    public void SetMultiplier(int val) => multiplyValue = val;
    public void SetMultiplierText(string val) => multiplierText.text = val;

}
