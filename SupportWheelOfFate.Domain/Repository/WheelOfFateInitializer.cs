﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using SupportWheelOfFate.Domain.Model;

namespace SupportWheelOfFate.Domain.Repository
{
    public class WheelOfFateInitializer : CreateDatabaseIfNotExists<WheelOfFateContext>
    {
        protected override void Seed(WheelOfFateContext context)
        {
            context.SuportEngineers.Add(new SupportEngineer("John", new List<Shift>()));
            context.SuportEngineers.Add(new SupportEngineer("Ben", new List<Shift>()));
            context.SuportEngineers.Add(new SupportEngineer("Ian", new List<Shift>()));
            context.SuportEngineers.Add(new SupportEngineer("Peter", new List<Shift>()));
            context.SuportEngineers.Add(new SupportEngineer("George", new List<Shift>()));
            context.SuportEngineers.Add(new SupportEngineer("Sam", new List<Shift>()));
            context.SuportEngineers.Add(new SupportEngineer("Danny", new List<Shift>()));
            context.SuportEngineers.Add(new SupportEngineer("Jo", new List<Shift>()));
            context.SuportEngineers.Add(new SupportEngineer("Elliot", new List<Shift>()));
            context.SuportEngineers.Add(new SupportEngineer("Rudolph", new List<Shift>()));
            base.Seed(context);
        }
    }
}
