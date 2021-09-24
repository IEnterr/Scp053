# Scp053
Exiled-Plugin for SCP:SL

SCP-053 Young Girl.



Description: When someone hurt SCP-053 - he dies (Except SCP)

permissions: 053

| Config | Description |Value Type | Default |
| --- | --- | --- | --- |
| is_enabled | Is enabled plugin or disabled | bool | true |
| spawn_message | The message that will appear when player spawns as SCP-053 | string | "You are SCP-053!" |
| use_hints | Will use hints or broadcast for spawn_message | bool | true |
| global_message | The message that will appear to all players when SCP-053 spawns  | string | "The <color=red>SCP-053</color> has spawned this round!" |
| global_message_duration | The broadcast duration  | int | 6 |
| spawn_chance |  The chance to spawn SCP-053 in round | int | 12 |

Commands:

| Command | permission | RACommand | Description |
| --- | --- | --- | --- |
| spawn | 053.spawn | 053 spawn [PlayerID] | Spawn player as SCP-053 |
| destroy | 053.destroy | 053 destroy | Destroy all SCP-053 |
