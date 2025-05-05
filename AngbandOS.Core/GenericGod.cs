// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal class GenericGod : God
{
    public GenericGod(Game game, GodGameConfiguration godGameConfiguration) : base(game)
    {
        Key = godGameConfiguration.Key ?? godGameConfiguration.GetType().Name;
        LongName = godGameConfiguration.LongName;
        ShortName = godGameConfiguration.ShortName;
        FavorDescription = godGameConfiguration.FavorDescription;
    }

    public override string LongName { get; }
    public override string ShortName { get; }

    public override string FavorDescription { get; }

    public override string Key { get; }
}
