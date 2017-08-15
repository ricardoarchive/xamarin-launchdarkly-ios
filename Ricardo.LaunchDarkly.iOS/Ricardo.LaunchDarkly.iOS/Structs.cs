using System;

namespace Ricardo.LaunchDarkly.iOS
{
    #region LaunchDarkly

	public enum DarklyLogLevel : uint
	{
	    None = 0,
	    CriticalOnly,
	    Debug,
	    All
	}

	public enum PollingState : uint
	{
	    Stopped = 0,
	    Paused = 1,
	    Running = 2,
	    Suspended = 3
	}

	#endregion LaunchDarkly

	#region DarklyEventSource

	public enum LDEventState : uint
	{
	    Connecting = 0,
	    Open = 1,
	    Closed = 2
	}

	#endregion DarklyEventSource
}
