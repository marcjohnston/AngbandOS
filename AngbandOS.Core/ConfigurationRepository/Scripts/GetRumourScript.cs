// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class GetRumourScript : Script
{
    private GetRumourScript(SaveGame saveGame) : base(saveGame) { }

    public override bool Execute()
    {
        string rumor;
        // Build an array of all the possible rumours we can get
        char[] rumorType = new char[SaveGame.Quests.Count + SaveGame.DungeonCount + SaveGame.DungeonCount];
        int[] rumorIndex = new int[SaveGame.Quests.Count + SaveGame.DungeonCount + SaveGame.DungeonCount];
        int maxRumor = 0;
        // Add a rumour for each undiscovered quest
        for (int i = 0; i < SaveGame.Quests.Count; i++)
        {
            if (SaveGame.Quests[i].Level > 0 && !SaveGame.Quests[i].Discovered)
            {
                rumorType[maxRumor] = 'q';
                rumorIndex[maxRumor] = i;
                maxRumor++;
            }
        }
        for (int i = 0; i < SaveGame.DungeonCount; i++)
        {
            // Add a rumour for each dungeon we don't know the depth of
            if (!SaveGame.SingletonRepository.Dungeons[i].KnownDepth)
            {
                rumorType[maxRumor] = 'd';
                rumorIndex[maxRumor] = i;
                maxRumor++;
            }
            //Add a rumour for each dungeon we don't know the offset of
            if (!SaveGame.SingletonRepository.Dungeons[i].KnownOffset)
            {
                rumorType[maxRumor] = 'o';
                rumorIndex[maxRumor] = i;
                maxRumor++;
            }
        }
        // If we already know everything, we're going to need to be told something so add all
        // the quest rumours and we'll get given a repeat of one of those
        if (maxRumor == 0)
        {
            maxRumor = 0;
            for (int i = 0; i < SaveGame.Quests.Count; i++)
            {
                rumorType[maxRumor] = 'q';
                rumorIndex[maxRumor] = i;
                maxRumor++;
            }
        }
        // Pick a random rumour from the list
        int choice = SaveGame.Rng.RandomLessThan(maxRumor);
        char type = rumorType[choice];
        int index = rumorIndex[choice];
        // Give us the appropriate information based on the rumour's type
        if (type == 'q')
        {
            // The rumour describes a quest
            SaveGame.Quests[index].Discovered = true;
            rumor = SaveGame.Quests[index].Describe();
        }
        else if (type == 'd')
        {
            // The rumour describes a dungeon depth
            Dungeon d = SaveGame.SingletonRepository.Dungeons[index];
            rumor = d.Tower
                ? $"They say that {d.Name} has {d.MaxLevel} floors."
                : $"They say that {d.Name} has {d.MaxLevel} levels.";
            d.KnownDepth = true;
        }
        else
        {
            // The rumour describes a dungeon difficulty
            Dungeon d = SaveGame.SingletonRepository.Dungeons[index];
            rumor = $"They say that {d.Name} has a relative difficulty of {d.Offset}.";
            d.KnownOffset = true;
        }
        SaveGame.MsgPrint(rumor);
        return false;
    }
}
