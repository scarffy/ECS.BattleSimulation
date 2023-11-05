using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Entities.UniversalDelegates;
using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.UIElements;
using System.Globalization;

[UpdateInGroup(typeof(NormalTickSimulationSystemGroup))]
[BurstCompile]
public partial class UnitSpawnerSystem : SystemBase
{

    private GameInput _inputActions;


    float3 WorldPos;
    bool GridClicked;
    bool Spawn;
    bool DeSpawn;

    protected override void OnCreate()
    {
        RequireForUpdate<SystemTickTrackerComponent>();
        RequireForUpdate<GridComponent>();
        RequireForUpdate<GameUnitListComponent>();
        RequireForUpdate<RandomComponent>();

        _inputActions = new GameInput();
        _inputActions.Enable();

        _inputActions.Player.GridClick.performed += GridClick_performed;
        _inputActions.Player.GridClick.canceled += GridClick_canceled;


        _inputActions.Player.ScreenClickPos.performed += ScreenClickPos_performed;
        _inputActions.Player.ScreenClickPos.canceled += ScreenClickPos_canceled;

        _inputActions.Player.Spawn.performed += Spawn_performed;
        _inputActions.Player.Spawn.canceled += Spawn_canceled;

        _inputActions.Player.DeSpawn.performed += DeSpawn_performed;
        _inputActions.Player.DeSpawn.canceled += DeSpawn_canceled;
    }

    private void DeSpawn_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        DeSpawn = false;
    }

    private void DeSpawn_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        DeSpawn = true;
    }

    private void Spawn_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Spawn = false;
    }

    private void Spawn_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Spawn = true;
    }

    private void ScreenClickPos_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        
    }

    private void ScreenClickPos_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Vector2 vector = obj.ReadValue<Vector2>();

        Ray ray = Camera.main.ScreenPointToRay(vector);

        Plane m_Plane;
        m_Plane = new Plane(Vector3.up,Vector3.zero);

        float enter = 0.0f;

        if (m_Plane.Raycast(ray, out enter))
        {
            WorldPos = ray.GetPoint(enter);

        }
    }

    private void GridClick_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        GridClicked = false;
    }

    private void GridClick_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        GridClicked = true;
    }

    protected override void OnDestroy()
    {
        _inputActions.Disable();

        _inputActions.Player.GridClick.performed -= GridClick_performed;
        _inputActions.Player.GridClick.canceled -= GridClick_canceled;


        _inputActions.Player.ScreenClickPos.performed -= ScreenClickPos_performed;
        _inputActions.Player.ScreenClickPos.canceled -= ScreenClickPos_canceled;

        _inputActions.Player.Spawn.performed -= Spawn_performed;
        _inputActions.Player.Spawn.canceled -= Spawn_canceled;

        _inputActions.Player.DeSpawn.performed -= DeSpawn_performed;
        _inputActions.Player.DeSpawn.canceled -= DeSpawn_canceled;
    }

    float DelayCounter = 0.25f;

    protected override void OnUpdate()
    {

        EntityCommandBuffer commandBuffer = SystemAPI.GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(World.Unmanaged);
        var GameUnitList = SystemAPI.GetSingleton<GameUnitListComponent>();

        var random = SystemAPI.GetSingletonRW<RandomComponent>();

        bool HasPlayerUnit = false;
        bool HasEnemyUnit = false;

        foreach(PlayerTag playerTag in SystemAPI.Query<PlayerTag>())
        {
            HasPlayerUnit = true;
        }

        foreach (EnemyTag enemyTag in SystemAPI.Query<EnemyTag>())
        {
            HasEnemyUnit = true;
        }

        if(HasPlayerUnit && HasEnemyUnit)
        {
            GameManager.Instance.GameReady();
        }



        if(GameManager.Instance.GamePlayState==GameState.PLAYING)
        {

            

            foreach ((EnemyTag Tag,Entity entity) in SystemAPI.Query<EnemyTag>().WithAbsent<IsReadyTag>().WithEntityAccess())
            {
                commandBuffer.AddComponent(entity, new IsReadyTag { });
            }
            foreach ((PlayerTag Tag, Entity entity) in SystemAPI.Query<PlayerTag>().WithAbsent<IsReadyTag>().WithEntityAccess())
            {
                commandBuffer.AddComponent(entity, new IsReadyTag { });
            }

            if(!HasPlayerUnit || !HasEnemyUnit)
            {
                GameManager.Instance.GameOver();
                if(HasPlayerUnit)
                {
                    GameManager.Instance.GameOverMassage = "Player Win";
                }
                else if(HasEnemyUnit)
                {
                    GameManager.Instance.GameOverMassage = "Enemy Win";
                }
                else
                {
                    GameManager.Instance.GameOverMassage = "Draw Game";
                }
            }

        }



        bool Restarted = false;

        foreach (var gridComponent in SystemAPI.Query<RefRW<GridComponent>>())
        {
            if (GameManager.Instance.GamePlayState == GameState.WAITING)
            {
                if (gridComponent.ValueRO.CleanUp == true)
                {
                    gridComponent.ValueRW.CleanUp = false;
                    gridComponent.ValueRW.Processed = false;

                    Restarted = true;
                }
            }

            if (GameManager.Instance.GamePlayState == GameState.PLAYING)
            {
                gridComponent.ValueRW.UnSelectCell();
                gridComponent.ValueRW.CleanUp = true;
                GameManager.Instance.Ready = SpawnState.PLAYER;
                continue;
            }

            if(gridComponent.ValueRO.SpawnType == SpawnType.PLAYER && gridComponent.ValueRO.TotalUnit==0 && GameManager.Instance.Ready == SpawnState.ENEMY)
            {
                GameManager.Instance.Ready = SpawnState.PLAYER;
                continue;
            }

            if (GameManager.Instance.Ready == SpawnState.PLAYER && gridComponent.ValueRO.SpawnType == SpawnType.PLAYER)
            {

                if (GridClicked)
                {
                    gridComponent.ValueRW.SelectCell(WorldPos);
                }

                if (gridComponent.ValueRO.IsSelected() && Spawn)
                {
                    DynamicBuffer<DynamicGridCellItem> gridCells = World.EntityManager.GetBuffer<DynamicGridCellItem>(gridComponent.ValueRO.entity);
                    int index = gridComponent.ValueRO.GetBufferIndex(gridComponent.ValueRO.GetSelectedCellPosition());
                    if (index >= 0)
                        if (World.EntityManager.HasComponent<IsValidTag>(gridCells[index].entity))
                        {
                            continue;
                        }

                    if (gridComponent.ValueRO.TotalUnit >= 5)
                        continue;

                    if (GameManager.Instance != null)
                        for (int i = 0; i < GameUnitList.UnitList.Count; i++)
                        {
                            if (GameManager.Instance.SelectedData.UnitID == GameUnitList.UnitList[i].unitId.ToString())
                            {
                                var entity = commandBuffer.CreateEntity();
                                commandBuffer.AddComponent(entity, new SpawnComponent { spawnType = gridComponent.ValueRO.SpawnType, gobject = GameUnitList.UnitList[i].entity, Position = gridComponent.ValueRO.GetSelectedCellPosition() });
                            }
                        }
                }



                continue;
            }

            if (GameManager.Instance.Ready == SpawnState.ENEMY && gridComponent.ValueRO.SpawnType == SpawnType.ENEMY)
            {
                DelayCounter -= SystemAPI.Time.DeltaTime;

                if (DelayCounter > 0)
                    continue;

                DelayCounter= 0.25f;


                Spawn = true;

                List<uint2> freeindex = new List<uint2>();
                DynamicBuffer<DynamicGridCellItem> gridCells = World.EntityManager.GetBuffer<DynamicGridCellItem>(gridComponent.ValueRO.entity);

                for(uint i=0;i<3;i++)
                {
                    for(uint j=0;j<3;j++)
                    {
                        int index = gridComponent.ValueRO.GetBufferIndex(new uint2(i,j));
                        if (index >= 0)
                        {
                            if (World.EntityManager.HasComponent<IsValidTag>(gridCells[index].entity))
                            {

                            }
                            else
                            {
                                freeindex.Add(new uint2(i, j));
                            }
                        }
                    }
                }


                gridComponent.ValueRW.SelectCell(freeindex[random.ValueRW.random.NextInt(0, freeindex.Count)]);

                if (gridComponent.ValueRO.IsSelected() && Spawn)
                {
                    int index = gridComponent.ValueRO.GetBufferIndex(gridComponent.ValueRO.GetSelectedCellPosition());
                    if (index >= 0)
                        if (World.EntityManager.HasComponent<IsValidTag>(gridCells[index].entity))
                        {
                            continue;
                        }

                    if (gridComponent.ValueRO.TotalUnit >= 5)
                    {
                        GameManager.Instance.Ready = SpawnState.COMPLETE;
                        continue;
                    }

                    if (GameManager.Instance != null)
                    {
                        var entity = commandBuffer.CreateEntity();
                        commandBuffer.AddComponent(entity, new SpawnComponent { spawnType = gridComponent.ValueRO.SpawnType, gobject = GameUnitList.UnitList[random.ValueRW.random.NextInt(0, GameUnitList.UnitList.Count)].entity, Position = gridComponent.ValueRO.GetSelectedCellPosition() });
                    }
                }


                continue;
            }
            
        }

        GridClicked = false;
        Spawn = false;


        if (Restarted)
        {
            foreach ((IsValidTag Tag, Entity entity) in SystemAPI.Query<IsValidTag>().WithEntityAccess())
            {
                commandBuffer.RemoveComponent<IsValidTag>(entity);
                commandBuffer.AddComponent(entity, new CleanUpTag { });
            }
        }


    }
}
