using UnityEngine;

public class PlayerTanmakManager
{
    //#todo: MonoPooledObject �����ڸ� ���� ������Ʈ ��ȯ�� ���������� �ڰ������ϱ�
    private MonoObjectPooler _pooler;
    public PlayerTanmakManager(MonoObjectPooler pPooler)
    {
        _pooler = pPooler;
    }
}
