using ASP.NETCoreWebApplication2.Models;
using ASP.NETCoreWebApplication2.Player;
using ASP.NETCoreWebApplication2.Player.Entity;

namespace ASP.NETCoreWebApplication2.Mapper
{
	public static class PlayerMapper
	{
		public static HockeyPlayer MapToDs(HockeyPlayerData entity)
		{
			return new HockeyPlayer(
				Id: entity.Id,
				Name: entity.Name,
				Skill: new PlayerSkill(
					Speed: entity.Speed,
					Stamina: entity.Stamina,
					Staking: entity.Staking,
					Shot: entity.Shot,
					Pass: entity.Pass,
					ReceivingPuck: entity.ReceivingPuck,
					Vision: entity.Vision,
					Opening: entity.Opening,
					Dribbling: entity.Dribbling,
					PuckSelection: entity.PuckSelection,
					GuardianShip: entity.GuardianShip,
					Interception: entity.Interception
				),
				Role: entity.Role,
				PreferredTeam: entity.PreferredTeam,
				IsVeteran: entity.IsVeteran
			);
		}

		public static HockeyPlayerViewModel MapToDto(HockeyPlayerData player)
		{
			return new HockeyPlayerViewModel(player.Id, (int)player.Role, player.Name);
		}

		public static HockeyPlayerViewModel MapToDto(HockeyPlayer player)
		{
			return new HockeyPlayerViewModel(player.Id, (int)player.Role, player.Name);
		}
	}
}
