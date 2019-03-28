﻿using System;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Services;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Services;

namespace Mmu.Jsc.ConsoleUI
{
    public static class Program
    {
        public static void Main()
        {
            var containerConfig = ContainerConfiguration.CreateFromAssembly(typeof(Program).Assembly, logInitialization: true);
            var container = ContainerInitializationService.CreateInitializedContainer(containerConfig);
            container
                .GetInstance<IConsoleCommandsStartupService>()
                .Start();
        }
    }
}
