using DigitalData.Domain.Entities.Planning;
using DigitalData.Domain.Entities.SubItem;
using DigitalData.Domain.Planning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.Item
{
    public class ItemEntity
    {
        //empty constructor for fastmapper purpose
        public ItemEntity()
        {

        }

        //Construtor de criação da VM
        public ItemEntity(int id, string name, string description, bool Desdobramento)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Desdobramento = Desdobramento;
            this.CreationDate = DateTime.Now;
            this.LastUpdate = DateTime.Now;
            this.IsActive = true;
        }

        // Construtor de leitura de objetos do banco
        public ItemEntity(int id, string name, string description, bool Desdobramento, bool isActive, DateTime creationDate, DateTime? lastUpdate)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Desdobramento = Desdobramento;
            this.IsActive = isActive;
            this.CreationDate = creationDate;
            this.LastUpdate = lastUpdate;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Desdobramento { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? LastUpdate { get; set; }

        public List<PlanningEntity> MonthPlanning { get; set; }

        public PlanningEntity YearPlanning { get; set; }
        
        public List<SubItemEntity> SubItems { get; set; }
    }
}
