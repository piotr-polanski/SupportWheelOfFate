using System;
using System.Collections.Generic;
using System.Data.Entity;
using SupportWheelOfFate.Domain.Model;

namespace SupportWheelOfFate.Domain.Repository
{
    public class WheelOfFateInitializer : CreateDatabaseIfNotExists<WheelOfFateContext>
    {
        protected override void Seed(WheelOfFateContext context)
        {
            context.SuportEngineers.Add(new SupportEngineerDto("John", new List<Shift>()));
            context.SuportEngineers.Add(new SupportEngineerDto("Ben", new List<Shift>()));
            context.SuportEngineers.Add(new SupportEngineerDto("Ian", new List<Shift>()));
            context.SuportEngineers.Add(new SupportEngineerDto("Peter", new List<Shift>()));
            context.SuportEngineers.Add(new SupportEngineerDto("George", new List<Shift>()));
            context.SuportEngineers.Add(new SupportEngineerDto("Sam", new List<Shift>()));
            context.SuportEngineers.Add(new SupportEngineerDto("Danny", new List<Shift>()));
            context.SuportEngineers.Add(new SupportEngineerDto("Jo", new List<Shift>()));
            context.SuportEngineers.Add(new SupportEngineerDto("Elliot", new List<Shift>()));
            context.SuportEngineers.Add(new SupportEngineerDto("Rudolph", new List<Shift>()));
            base.Seed(context);
        }
    }
}
