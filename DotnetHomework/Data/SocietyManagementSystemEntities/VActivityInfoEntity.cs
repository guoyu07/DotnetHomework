using System;

namespace DotnetHomework.Data.SocietyManagementSystemEntities
{
    public class VActivityInfoEntity
    {
        public int Id { get; set; }

        public int SocietyId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Nullable<DateTime> Time { get; set; }

        public Nullable<DateTime> CreateTime { get; set; }

        public string Status { get; set; }

        public string Reason { get; set; }

        public string SocietyName { get; set; }

        public string SocietyDescription { get; set; }
    }
}
