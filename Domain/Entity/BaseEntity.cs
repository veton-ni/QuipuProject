﻿

namespace Domain.Entity
{
    public class BaseEntity
    {

        public Guid Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
