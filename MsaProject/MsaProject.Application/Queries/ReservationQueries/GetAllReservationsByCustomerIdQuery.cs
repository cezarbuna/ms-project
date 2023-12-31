﻿using MediatR;
using MsaProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Application.Queries.ReservationQueries
{
    public class GetAllReservationsByCustomerIdQuery : IRequest<List<Reservation>>
    {
        public Guid CustomerId { get; set; }
    }
}
