﻿using ISTCOSA.Application.Common.DTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.CommandAndQuries.RollNumbers.Queries.GetRollNumbers
{
    public class GetAllRollNumbersQuery : IRequest<List<RollNumberDTO>>
    {
        public int RollNumberId { get; set; }
        public int RollNumbers { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
