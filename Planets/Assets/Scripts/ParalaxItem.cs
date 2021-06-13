using UnityEngine;

[System.Serializable]
public class ParalaxItem
{
    public Transform Image;
    public float Smoothnes;

    [HideInInspector] public Vector3 NextPosition = new Vector3(0, 0, 0);
}
