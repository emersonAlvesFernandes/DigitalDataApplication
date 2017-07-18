using DigitalData.Domain.Planning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalData.WebApiStarter.Models.Entities.Planning
{
    public class PlanningReadCollectionDto
    {
        List<PlanningEntity> MonthlyPlanning { get; set; }

        PlanningEntity YearPlanning { get; set; }

        public PlanningReadCollectionDto(IDictionary<PlanningEntity, List<PlanningEntity>> dictionary)
        {
            YearPlanning = dictionary.Keys.First();
            MonthlyPlanning = dictionary.Values.First();
        }        
    }
}