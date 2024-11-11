using UnityEngine;

public class PlayerTanmakManager
{
    //#todo: MonoPooledObject 생성자를 통한 오브젝트 소환이 가능해지면 자가생성하기
    private MonoObjectPooler _pooler;
    public PlayerTanmakManager(MonoObjectPooler pPooler)
    {
        _pooler = pPooler;
    }
}
