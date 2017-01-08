using System;

namespace DotnetHomework.Data.SocietyManagementSystemEntities
{
    public class SocietyEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Category { get; set; }

        public string Description { get; set; }

        public string Creator { get; set; }

        public DateTime? CreateTime { get; set; }

        public string Status { get; set; }

        public string Reason { get; set; }
    }
}