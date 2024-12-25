using System;
using System.Collections.Generic;

using ASCOM.DeviceInterface;

namespace ASCOM.DeviceHub
{
	public class TelescopeHandbox : DevicePropertiesBase, ICloneable
	{
		public static TelescopeHandbox GetFullHandbox()
		{
			// Use the alternate constructor to return an instance with all the
			// handbox set to true. The axis rates are still null.

			return new TelescopeHandbox( true );
		}

		#region Constructors

		public TelescopeHandbox()
		{}

		public TelescopeHandbox( TelescopeManager mgr )
		{
			DeviceManager = mgr;
		}

		private TelescopeHandbox( bool fullHandbox )
		{
			DeviceManager = null;

			Initialize( fullHandbox );
		}

		public TelescopeHandbox(TelescopeHandbox other)
		{
			this.DeviceManager = other.DeviceManager;
			this.Exceptions = other.Exceptions.Clone();
		}

		#endregion Constructors

		#region Change Notification Properties

		/*

		private bool _canFindHome;

		public bool CanFindHome
		{
			get { return _canFindHome; }
			set
			{
				if ( value != _canFindHome )
				{
					_canFindHome = value;
					OnPropertyChanged();
				}
			}
		}

		private bool _canPark;

		public bool CanPark
		{
			get { return _canPark; }
			set
			{
				if ( value != _canPark )
				{
					_canPark = value;
					OnPropertyChanged();
				}
			}
		}

		private bool _canPulseGuide;

		public bool CanPulseGuide
		{
			get { return _canPulseGuide; }
			set
			{
				if ( value != _canPulseGuide )
				{
					_canPulseGuide = value;
					OnPropertyChanged();
				}
			}
		}

		private bool _canSetDeclinationRate;

		public bool CanSetDeclinationRate
		{
			get { return _canSetDeclinationRate; }
			set
			{
				if ( value != _canSetDeclinationRate )
				{
					_canSetDeclinationRate = value;
					OnPropertyChanged();
				}
			}
		}

		private bool _canSetGuideRates;

		public bool CanSetGuideRates
		{
			get { return _canSetGuideRates; }
			set
			{
				if ( value != _canSetGuideRates )
				{
					_canSetGuideRates = value;
					OnPropertyChanged();
				}
			}
		}

		private bool _canSetPark;

		public bool CanSetPark
		{
			get { return _canSetPark; }
			set
			{
				if ( value != _canSetPark )
				{
					_canSetPark = value;
					OnPropertyChanged();
				}
			}
		}

		private bool _canSetPierSide;

		public bool CanSetPierSide
		{
			get { return _canSetPierSide; }
			set
			{
				if ( value != _canSetPierSide )
				{
					_canSetPierSide = value;
					OnPropertyChanged();
				}
			}
		}

		private bool _canSetRightAscensionRate;

		public bool CanSetRightAscensionRate
		{
			get { return _canSetRightAscensionRate; }
			set
			{
				if ( value != _canSetRightAscensionRate )
				{
					_canSetRightAscensionRate = value;
					OnPropertyChanged();
				}
			}
		}

		private bool _canSetTracking;

		public bool CanSetTracking
		{
			get { return _canSetTracking; }
			set
			{
				if ( value != _canSetTracking )
				{
					_canSetTracking = value;
					OnPropertyChanged();
				}
			}
		}

		private bool _canSlew;

		public bool CanSlew
		{
			get { return _canSlew; }
			set
			{
				if ( value != _canSlew )
				{
					_canSlew = value;
					OnPropertyChanged();
				}
			}
		}

		private bool _canSlewAltAz;

		public bool CanSlewAltAz
		{
			get { return _canSlewAltAz; }
			set
			{
				if ( value != _canSlewAltAz )
				{
					_canSlewAltAz = value;
					OnPropertyChanged();
				}
			}
		}

		private bool _canSlewAltAzAsync;

		public bool CanSlewAltAzAsync
		{
			get { return _canSlewAltAzAsync; }
			set
			{
				if ( value != _canSlewAltAzAsync )
				{
					_canSlewAltAzAsync = value;
					OnPropertyChanged();
				}
			}
		}

		private bool _canSlewAsync;

		public bool CanSlewAsync
		{
			get { return _canSlewAsync; }
			set
			{
				if ( value != _canSlewAsync )
				{
					_canSlewAsync = value;
					OnPropertyChanged();
				}
			}
		}

		private bool _canSync;

		public bool CanSync
		{
			get { return _canSync; }
			set
			{
				if ( value != _canSync )
				{
					_canSync = value;
					OnPropertyChanged();
				}
			}
		}

		private bool _canSyncAltAz;

		public bool CanSyncAltAz
		{
			get { return _canSyncAltAz; }
			set
			{
				if ( value != _canSyncAltAz )
				{
					_canSyncAltAz = value;
					OnPropertyChanged();
				}
			}
		}

		private bool _canUnpark;

		public bool CanUnpark
		{
			get { return _canUnpark; }
			set
			{
				if ( value != _canUnpark )
				{
					_canUnpark = value;
					OnPropertyChanged();
				}
			}
		}

		private bool _canMovePrimaryAxis;

		public bool CanMovePrimaryAxis
		{
			get { return _canMovePrimaryAxis; }
			set
			{
				if ( value != _canMovePrimaryAxis )
				{
					_canMovePrimaryAxis = value;
					OnPropertyChanged();
				}
			}
		}

		private bool _canMoveSecondaryAxis;

		public bool CanMoveSecondaryAxis
		{
			get { return _canMoveSecondaryAxis; }
			set
			{
				if ( value != _canMoveSecondaryAxis )
				{
					_canMoveSecondaryAxis = value;
					OnPropertyChanged();
				}
			}
		}

		private bool _canMoveTertiaryAxis;

		public bool CanMoveTertiaryAxis
		{
			get { return _canMoveTertiaryAxis; }
			set
			{
				if ( value != _canMoveTertiaryAxis )
				{
					_canMoveTertiaryAxis = value;
					OnPropertyChanged();
				}
			}
		}

		private IRate[] _primaryAxisRates;

		public IRate[] PrimaryAxisRates
		{
			get { return _primaryAxisRates; }
			set
			{
				if ( value != _primaryAxisRates )
				{
					_primaryAxisRates = value;
					OnPropertyChanged();
				}
			}
		}

		private IRate[] _secondaryAxisRates;

		public IRate[] SecondaryAxisRates
		{
			get { return _secondaryAxisRates; }
			set
			{
				if ( value != _secondaryAxisRates )
				{
					_secondaryAxisRates = value;
					OnPropertyChanged();
				}
			}
		}

		private IRate[] _tertiaryAxisRates;

		public IRate[] TertiaryAxisRates
		{
			get { return _tertiaryAxisRates; }
			set
			{
				if ( value != _tertiaryAxisRates )
				{
					_tertiaryAxisRates = value;
					OnPropertyChanged();
				}
			}
		}
*/

		#endregion
		
		#region Public Methods

		#endregion

		#region Helper Methods

		private void Initialize( bool canValue )
		{
		}

		private IRate[] AxisRatesToArray( IAxisRates axisRates )
		{
			List<IRate> tempList = new List<IRate>();

			foreach ( IRate rate in axisRates )
			{
				tempList.Add( rate );
			}

			return tempList.ToArray();
		}

		#endregion

		#region ICloneable Methods

		object ICloneable.Clone()
		{
			return new TelescopeHandbox( this );
		}

		public TelescopeHandbox Clone()
		{
			return new TelescopeHandbox( this );
		}

		#endregion ICloneable Methods
	}
}
