using Unity.Entities;
using Unity.Entities.UniversalDelegates;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.EventSystems.EventTrigger;

[UpdateInGroup(typeof(PresentationSystemGroup))]
public partial struct PresentationLayerSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {

    }

    public void OnDestroy(ref SystemState state)
    {

    }

    public void OnUpdate(ref SystemState state)
    {

        EntityCommandBuffer commandBuffer = SystemAPI.GetSingleton<BeginPresentationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);

        foreach (var (plgo, entity) in SystemAPI.Query<PresentationComponent>().WithEntityAccess())
        {
            GameObject gobj = GameObject.Instantiate(plgo.Prefab);
            commandBuffer.RemoveComponent<PresentationComponent>(entity);

            commandBuffer.AddComponent(entity, new PresentationObjectComponent {
                PresentedObject= gobj,
                healthViewer = gobj.GetComponent<HealthViewer>(),
            });;
        }


        foreach (var (plgo, localtransform,isvalid) in SystemAPI.Query<PresentationObjectComponent,LocalTransform,IsValidTag>())
        {
            plgo.PresentedObject.transform.position = localtransform.Position;
        }


        foreach (var (plgo, health, isvalid) in SystemAPI.Query<PresentationObjectComponent, HealthComponent, IsValidTag>())
        {
            plgo.healthViewer.HealthValue = health.Value;
            plgo.healthViewer.AliveTimarCounter = plgo.healthViewer.AliveTimar;
        }

        foreach (var (plgo, selector,localtransform,entity) in SystemAPI.Query<PresentationEntityComponent, GridSelectorTag,LocalTransform>().WithEntityAccess())
        {
            var renderer = state.EntityManager.GetComponentData<URPMaterialPropertyBaseColor>(plgo.entity);
            Color color=Color.green;
            
            foreach (var gridComponent in SystemAPI.Query<RefRO<GridComponent>>())
            {
                DynamicBuffer<DynamicGridCellItem> gridCells = state.EntityManager.GetBuffer<DynamicGridCellItem>(gridComponent.ValueRO.entity);
                int index = gridComponent.ValueRO.GetBufferIndex(localtransform.Position);
                if (index >= 0 && gridCells[index].entity!=Entity.Null)
                {
                    color = Color.red;
                    
                }
            }

            renderer.Value = new float4(color.r, color.g, color.b, color.a);
            commandBuffer.SetComponent<URPMaterialPropertyBaseColor>(plgo.entity, renderer);
        }

        foreach (var (plgo, tag, entity, isvalid) in SystemAPI.Query<PresentationEntityComponent, PlayerTag, IsValidTag>().WithEntityAccess())
        {
            var renderer = state.EntityManager.GetComponentData<URPMaterialPropertyBaseColor>(plgo.entity);
            Color color = Color.blue;
            renderer.Value = new float4(color.r, color.g, color.b, color.a);
            commandBuffer.SetComponent<URPMaterialPropertyBaseColor>(plgo.entity, renderer);
        }

        foreach (var (plgo, tag, entity,isvalid) in SystemAPI.Query<PresentationEntityComponent, EnemyTag,IsValidTag>().WithEntityAccess())
        {
            var renderer = state.EntityManager.GetComponentData<URPMaterialPropertyBaseColor>(plgo.entity);
            Color color = Color.red;
            renderer.Value = new float4(color.r, color.g, color.b, color.a);
            commandBuffer.SetComponent<URPMaterialPropertyBaseColor>(plgo.entity, renderer);
        }

    }


    
}
