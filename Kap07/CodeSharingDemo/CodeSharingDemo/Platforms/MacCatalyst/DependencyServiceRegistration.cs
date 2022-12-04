﻿using CodeSharingDemo.MacCatalyst;

namespace CodeSharingDemo;

public static  class DependencyServiceRegistration
{
    public static void RegisterPlatformDependencies()
    {
        DependencyService.Register<MacCatalystDeviceInformation>();
    }
}
