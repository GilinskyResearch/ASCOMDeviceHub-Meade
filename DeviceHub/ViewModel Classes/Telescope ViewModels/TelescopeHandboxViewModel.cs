using System.Threading;
using System.Threading.Tasks;

using ASCOM.DeviceHub.MvvmMessenger;

namespace ASCOM.DeviceHub
{
	public class TelescopeHandboxViewModel : DeviceHubViewModelBase
	{
		public TelescopeHandboxViewModel()
		{
			string caller = "TelescopeHandboxViewModel ctor";
			LogAppMessage( "Initializing Instance constructor", caller );
			LogAppMessage( "Registering message handlers" , caller );

			Messenger.Default.Register<TelescopeHandboxUpdatedMessage>( this, ( action ) => UpdateHandbox( action ) );
			Messenger.Default.Register<DeviceDisconnectedMessage>( this, ( action ) => InvalidateHandbox( action ) );

			LogAppMessage( "Instance constructor initialization complete.", caller );
		}

		private TelescopeHandbox _handbox;

		public TelescopeHandbox Handbox
		{
			get { return _handbox; }
			set
			{
				if ( value != _handbox )
				{
					_handbox = value;
					OnPropertyChanged();
				}
			}
		}

		private void UpdateHandbox( TelescopeHandboxUpdatedMessage action )
		{
			SetHandbox( action.Handbox );
		}

		private void InvalidateHandbox( DeviceDisconnectedMessage action )
		{
			if ( action.DeviceType == DeviceTypeEnum.Telescope )
			{
				SetHandbox( null );
			}
		}

		private void SetHandbox( TelescopeHandbox handbox )
		{
			// Make sure that we update the Handbox on the U/I thread.

			Task.Factory.StartNew( () => Handbox = handbox, CancellationToken.None, TaskCreationOptions.None, Globals.UISyncContext );
		}

		protected override void DoDispose()
		{
			Messenger.Default.Unregister<DeviceDisconnectedMessage>( this );
			Messenger.Default.Unregister<TelescopeHandboxUpdatedMessage>( this );
		}
	}
}
