using Database.Model;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class FacadesClass
    {
        public FacadeAirplanes Airplanes { get; private set; }

        public FacadesClass()
        {
            foreach (var property in this.GetType().GetProperties())
            {
                property.SetValue(this, Activator.CreateInstance(property.PropertyType));
            }
        }
    }
}
