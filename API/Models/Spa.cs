using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Spa
    {
        public Spa()
        {
            Appointments = new HashSet<Appointment>();
            Assets = new HashSet<Asset>();
            Bulletins = new HashSet<Bulletin>();
            CustomerSegmentations = new HashSet<CustomerSegmentation>();
            Employees = new HashSet<Employee>();
            Products = new HashSet<Product>();
            Promotions = new HashSet<Promotion>();
            Rooms = new HashSet<Room>();
            Sales = new HashSet<Sale>();
            ServiceCards = new HashSet<ServiceCard>();
            Services = new HashSet<Service>();
            Transactions = new HashSet<Transaction>();
            UserRoles = new HashSet<UserRole>();
        }

        public int SpaId { get; set; }
        public string SpaName { get; set; } = null!;
        public string? Location { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int? ManagerId { get; set; }

        public virtual User? Manager { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Asset> Assets { get; set; }
        public virtual ICollection<Bulletin> Bulletins { get; set; }
        public virtual ICollection<CustomerSegmentation> CustomerSegmentations { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Promotion> Promotions { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<ServiceCard> ServiceCards { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
