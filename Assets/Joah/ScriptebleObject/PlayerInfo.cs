using UnityEngine;
[CreateAssetMenu(fileName = "PlayerInfo.asset", menuName = "Player Info", order = 0)]

public class PlayerInfo : GenericScriptableSingleton<PlayerInfo>
{
    public int level;
}
