using UnityEngine;


[CreateAssetMenu(fileName = "New Color", menuName = "Fuel Colors/Colors", order = 0)]
public class CarColor : ScriptableObject
{
    [SerializeField]   public Color color; [SerializeField]  
    public ColorName colorName;
}
