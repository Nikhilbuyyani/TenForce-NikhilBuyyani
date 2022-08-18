using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Test_Taste_Console_Application.Domain.DataTransferObjects;

namespace Test_Taste_Console_Application.Domain.Objects
{
    public class Planet
    {
        public string Id { get; set; }
        public float SemiMajorAxis { get; set; }
        public ICollection<Moon> Moons { get; set; }
        public float AverageMoonGravity
        {
            //Calculating the average moon gravity using extension methods
            get => Moons.Average(g => g.Gravity);
            //get;           //Approach-2 get 
            //private set;   //Approach-2  private set 
        }

        public Planet(PlanetDto planetDto)
        {
           // float totalGravity = 0.0f;  //Approach-2 Declare totalgravity value as default initially
            Id = planetDto.Id;
            SemiMajorAxis = planetDto.SemiMajorAxis;
            Moons = new Collection<Moon>();
            if(planetDto.Moons != null)
            {
                foreach (MoonDto moonDto in planetDto.Moons)
                {
                    Moons.Add(new Moon(moonDto));
                   // totalGravity = totalGravity + moonDto.Gravity;   //Approach-2 calculating the total gravity
                }
               // AverageMoonGravity = (totalGravity / Moons.Count); //Approach-2 calculating the average moon gravity
            }
        }

        public Boolean HasMoons()
        {
            return (Moons != null && Moons.Count > 0);
        }
    }
}
