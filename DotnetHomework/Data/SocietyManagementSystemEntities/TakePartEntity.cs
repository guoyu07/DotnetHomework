﻿using System;

namespace DotnetHomework.Data.SocietyManagementSystemEntities
{
    public class TakePartEntity
    {
        public int Id { get; set; }

        public string User { get; set; }

        public int Activity { get; set; }

        public Nullable<DateTime> Time{ get; set; }
    }
}