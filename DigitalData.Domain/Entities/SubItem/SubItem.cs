using DigitalData.Domain.Entities.Planning;
using DigitalData.Domain.Planning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.SubItem
{
    public class SubItemEntity
    {
        public SubItemEntity(
            int id,
            string name, 
            string description, 
            bool isActive, 
            DateTime creationDate,
            DateTime? lastUpdate)
        {
            Id = id;
            Name = name;
            Description = description;
            IsActive = isActive;
            CreationDate = creationDate;
            LastUpdate = lastUpdate;
        }

        public int Id { get;  set; }

        public string Name { get;  private set; }

        public string Description { get;  private set; }        

        public bool IsActive { get;  private set; }

        public DateTime CreationDate { get;  private set; }

        public DateTime? LastUpdate { get;  private set; }

        public List<PlanningEntity> MonthPlanning { get;  private set; }

        public PlanningEntity YearPlanning { get;  private set; }

        //public SubItemEntity GetNew(string name, string description)
        //{
        //    var obj = new SubItemEntity()
        //    {                
        //        Name = name,
        //        Description = description,
        //        IsActive = true,
        //        CreationDate = DateTime.Now,
        //        LastUpdate = DateTime.Now,                
        //    };

        //    return obj;
        //}

        public void SetSubItemEntity(int id
            , string name
            , string description
            , bool isActive
            , DateTime creationDate
            , DateTime? lastupdate)
        {
            Id = id;
            Name = name;
            Description = description;
            IsActive = isActive;
            CreationDate = creationDate;
            LastUpdate = lastupdate;
        }

        public void SetSubItemEntity(int id
            , string name
            , string description
            , bool isActive
            , DateTime creationDate
            , DateTime? lastupdate
            , List<PlanningEntity> monthPlanning
            , PlanningEntity yearPlanning
            )
        {
            Id = id;
            Name = name;
            Description = description;
            IsActive = isActive;
            CreationDate = creationDate;
            LastUpdate = lastupdate;
            MonthPlanning = monthPlanning;
            YearPlanning = yearPlanning;
        }


    }
}
