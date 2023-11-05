using Unity.Entities;
using UnityEngine;

public class PresentationObjectComponent : IComponentData
{
    public GameObject PresentedObject;
    public HealthViewer healthViewer;
}
