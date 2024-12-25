namespace ASCOM.DeviceHub
{
	public class TelescopeHandboxUpdatedMessage
    {
		public TelescopeHandboxUpdatedMessage( TelescopeHandbox handbox)
		{
			Handbox = handbox;
		}

		public TelescopeHandbox Handbox { get; private set; }
	}
}
