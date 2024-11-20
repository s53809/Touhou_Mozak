using System;
using UnityEngine;

public class TanmakLevelInfo
{
    public String TanmakName { get; private set; }
    public Int32 Count { get; private set; }
    public Vector2[] SpawnPosition { get; private set; }
    public Vector2[] SpawnDirection { get; private set; }
    public Single TanmakCoolTime { get; private set; }

    public Single lastTanmakShootTime = 0;

    public TanmakLevelInfo(String tanmakName, Int32 count, Single coolTime, Vector2[] spawnPosition, Vector2[] spawnDirection)
    {
        TanmakName = tanmakName;
        Count = count;
        TanmakCoolTime = coolTime;
        SpawnPosition = spawnPosition;
        SpawnDirection = spawnDirection;
    }
}
public class PlayerTanmakManager
{
    //#todo: MonoPooledObject 생성자를 통한 오브젝트 소환이 가능해지면 자가생성하기
    private MonoObjectPooler _pooler;
    private TanmakLevelInfo[][] _levelInfo;
    private Transform characterPosition;
    
    public Int32 PlayerLevel { get; private set; }
    public PlayerTanmakManager(MonoObjectPooler pPooler, Transform pCharacterPosition, TanmakLevelInfo[][] pLevelInfo)
    {
        _pooler = pPooler;
        PlayerLevel = 0;
        _levelInfo = pLevelInfo;
        characterPosition = pCharacterPosition;
    }
    public void LevelUp()
    {
        if (PlayerLevel >= _levelInfo.Length - 1) return;
        else PlayerLevel++;
    }
    public void SetLevel(Int32 level)
    {
        if (level > _levelInfo.Length - 1) throw new Exception("Level is out of Range");
        PlayerLevel = level;
    }
    public void OnShoot()
    {
        var shootInfo = _levelInfo[PlayerLevel];
        foreach(var info in shootInfo)
        {
            if (Time.time < info.lastTanmakShootTime + info.TanmakCoolTime) continue;
            info.lastTanmakShootTime = Time.time;
            for(Int32 i = 0; i < info.Count; i++)
            {
                Tanmak obj = (Tanmak)_pooler.SpawnPoolObject(info.TanmakName);
                obj.startDir = info.SpawnDirection[i];
                obj.gameObject.transform.position 
                    = new Vector2(characterPosition.position.x, characterPosition.position.y) 
                    + info.SpawnPosition[i];
            }
        }
    }
}
