# Weather Test

4Com code test for prospective .NET developers.

To try and stay within the spirit of the exercise I set asside a few hours and stopped myself from doing more when the time was up.

This is a Unity / Prism MVVM wpf application inside the application folder -> weatherViewerApplication.

If I was to further refine the application.

	* Address the decoding of the downloaded string, I am not at all happy with the way I am determining which data set and docding data as this does not feel at all 
	  easily extensible, possibly a keyed collection of decoders, that are injected into here using a better mechanism of identification would make this easier to extend.
	
	* timeout mechanism is set to a hardcoded 3 seconds, so if the site is not availble it fails with a popup, maybe adding a retry and a different timeout to cope with slow sites,
	  making this time out configurable.