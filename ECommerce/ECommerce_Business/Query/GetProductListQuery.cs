﻿using Ecommerce_Domain.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Business.Query
{
    public class GetProductListQuery : IRequest<IList<Product>> 
    {
    }
}
