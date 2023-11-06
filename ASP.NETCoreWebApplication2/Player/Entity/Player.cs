using ASP.NETCoreWebApplication2.Player.Values;

namespace ASP.NETCoreWebApplication2.Player.Entity
{
	public record HockeyPlayerData(
		int Id,
		string Name,
		Role Role,
		TeamSide PreferredTeam,
		decimal Speed,
		decimal Stamina,
		decimal Staking,
		decimal Shot,
		decimal Pass,
		decimal ReceivingPuck,
		decimal Vision,
		decimal Opening,
		decimal Dribbling,
		decimal PuckSelection,
		decimal GuardianShip,
		decimal Interception,
		bool IsVeteran = false
	);
}
