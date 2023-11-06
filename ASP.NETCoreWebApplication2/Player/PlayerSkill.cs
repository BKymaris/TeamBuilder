using ASP.NETCoreWebApplication2.Code.Helper;

namespace ASP.NETCoreWebApplication2.Player
{
	public record PlayerSkill(
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
		decimal Interception
	)
	{
		private const int _QTY_PARAMS = 12;

		[property: CompareOrder(0)]
		public decimal Skill
		{
			get
			{
				var sum =
					Speed +
					Stamina +
					Staking +
					Shot +
					Pass +
					ReceivingPuck +
					Vision +
					Opening +
					Dribbling +
					PuckSelection +
					GuardianShip +
					Interception;

				return Math.Round(sum / _QTY_PARAMS, 2);
			}
		}
	}
}
