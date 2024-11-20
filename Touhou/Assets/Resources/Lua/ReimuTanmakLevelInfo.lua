VArray = LuaUtility.LuaTableToVectorArray


TEST = {1,2,3,4}

levels = {
    new = function(name, count, cooltime, spawnPosition, direction)
        return {
            Name = name or "",
            Count = count or 1,
            Cooltime = cooltime or 0.0,
            SpawnPosition = spawnPosition or VArray({Vector2(0, 0)}),
            Direction = direction or VArray({Vector2.up}),
        }
    end
}

reimuTanmakLevels = {
    {
        levels.new("ReimuDefaultTanmak", 1, 0.1, VArray({Vector2(0, 0.8)}), VArray({Vector2.up}))
    },
    {
        levels.new("ReimuDefaultTanmak", 2, 0.1,
        VArray({Vector2(-0.2, 0.8), Vector2(0.2, 0.8)}),
        VArray({Vector2.up, Vector2.up})
        )
    },
    {
        levels.new("ReimuDefaultTanmak", 3, 0.1,
        VArray({Vector2(-0.4, 0.8), Vector2(0, 0.8), Vector2(0.4, 0.8)}),
        VArray({Vector2.up, Vector2.down, Vector2.up})
        ),
        levels.new("ReimuFollowTanmak", 2, 0.4,
        VArray({Vector2(-0.5, 0), Vector2(0.5, 0)}),
        VArray({
            Vector2Util.RotateVector(Vector2.up, 45),
            Vector2Util.RotateVector(Vector2.up, -45)
        })
        )
    }
}

function ReturnTest()
    return reimuTanmakLevels;
end