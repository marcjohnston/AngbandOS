// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class CreateRandomArtifactScrollItemFactory : ScrollItemFactory
{
    private CreateRandomArtifactScrollItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(QuestionMarkSymbol));
    public override string Name => "Artifact Creation";

    public override int[] Chance => new int[] { 16, 0, 0, 0 };
    public override int Cost => 200000;
    public override string FriendlyName => "Artifact Creation";
    public override int LevelNormallyFound => 70;
    public override int[] Locale => new int[] { 70, 0, 0, 0 };
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        SaveGame.RunScript(nameof(CreateRandomArtifactScript));
        eventArgs.Identified = true;
    }
    public override Item CreateItem() => new Item(SaveGame, this);
}