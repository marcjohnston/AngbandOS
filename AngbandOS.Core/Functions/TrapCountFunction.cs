
// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

[Serializable]
internal class TrapCountFunction : IntFunction
{
    private TrapCountFunction(Game game) : base(game) { } // This object is a singleton.
    public override int Value => Game.CountTraps(Game.MapX.Value, Game.MapY.Value);

    public override string[]? DependencyNames => new string[]
    {
        nameof(MapXIntProperty),
        nameof(MapYIntProperty),
        nameof(TrapsDetectedProperty)
    };
}