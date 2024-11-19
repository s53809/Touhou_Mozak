import('Assembly-CSharp')
import('Assembly-CSharp', 'MinseoUtil')
import('UnityEngine')

local Test = {Vector2(0, 0), Vector2(0, 1)}

local reimuTanmakLevels = {
    {
        TanmakLevelInfo("ReimuDefaultTanmak", 1, 0.1,
            {Vector2(0, 0.8)},
            {Vector2.up}
        )
    },
    {
        TanmakLevelInfo("ReimuDefaultTanmak", 2, 0.1,
            {Vector2(-0.2, 0.8), Vector2(0.2, 0.8)},
            {Vector2.up, Vector2.up}
        )
    },
    {
        TanmakLevelInfo("ReimuDefaultTanmak", 3, 0.1,
            {Vector2(-0.4, 0.8), Vector2(0, 0.8), Vector2(0.4, 0.8)},
            {Vector2.up, Vector2.up, Vector2.up}
        ),
        TanmakLevelInfo("ReimuFollowTanmak", 2, 0.4,
            {Vector2(-0.5, 0), Vector2(0.5, 0)},
            {
                Vector2Util.RotateVector(Vector2.up, 45),
                Vector2Util.RotateVector(Vector2.up, -45)
            }
        )
    }
}