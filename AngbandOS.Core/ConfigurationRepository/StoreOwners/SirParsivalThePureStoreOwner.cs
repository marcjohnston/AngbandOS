// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

[Serializable]
internal class SirParsivalThePureStoreOwner : StoreOwner
{
    private SirParsivalThePureStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Sir Parsival the Pure";
    public override int MaxCost =>  25000;
    public override int MinInflate =>  107;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HighElfRace>();
}