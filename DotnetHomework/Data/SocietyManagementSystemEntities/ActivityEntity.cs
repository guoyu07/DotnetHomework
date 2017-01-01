using System;

namespace DotnetHomework.Data.SocietyManagementSystemEntities
{
    public class ActivityEntity
    {
        public int Id { get; set; }

        public int Society { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Nullable<DateTime> Time { get; set; }

        public string Status { get; set; }
    }
}