// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class NewLifePotionItemFactory : PotionItemFactory
{
    private NewLifePotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(ExclamationPointSymbol));
    public override string Name => "New Life";

    public override int[] Chance => new int[] { 20, 10, 5, 0 };
    public override int Cost => 750000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "New Life";
    public override int Level => 50;
    public override int[] Locale => new int[] { 50, 100, 120, 0 };
    public override int InitialTypeSpecificValue => 100;
    public override int Weight => 4;
    public override bool Quaff()
    {
        // New life rerolls your health, cures all mutations, and restores you to your birth race
        SaveGame.RunScript(nameof(RerollHitPointsScript));
        if (SaveGame.Dna.HasMutations)
        {
            SaveGame.MsgPrint("You are cured of all mutations.");
            SaveGame.Dna.LoseAllMutations();
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateBonusesFlaggedAction)).Set();
            SaveGame.HandleStuff();
        }
        if (!(SaveGame.Race.GetType() == SaveGame.RaceAtBirth.GetType()))
        {
            var oldRaceName = SaveGame.RaceAtBirth.Title;
            SaveGame.MsgPrint($"You feel more {oldRaceName} again.");
            SaveGame.ChangeRace(SaveGame.RaceAtBirth);
            SaveGame.RedrawSingleLocation(SaveGame.MapY, SaveGame.MapX);
        }
        return true;
    }
    public override Item CreateItem() => new Item(SaveGame, this);
}