using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EndSequence : MonoBehaviour
{
    [SerializeField] private List<GameObject> multiplierWalls = new List<GameObject>();

    [SerializeField] private Transform multiplierParent;
    
    [SerializeField] private float zOffset;

    // Start is called before the first frame update
    void Start()
    {
        BuildMultiplier();
    }

    private void BuildMultiplier()
    {
        float zVal = 0;
        var multiplier = 2;


        for (var i = 0; i < 9; i++)
        {
            var randomMultiplier = Random.Range(0, multiplierWalls.Count);

            var wall = Instantiate(multiplierWalls[randomMultiplier], multiplierParent, true);
            wall.transform.DOLocalMove(new Vector3(0, 0, zVal), 0);
            zVal += zOffset;
            wall.GetComponent<Multiplier>().SetMultiplierText(  "X "+multiplier);
            wall.GetComponent<Multiplier>().SetMultiplier(multiplier++);
          
        }
    }
}
