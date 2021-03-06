﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiteFx.Specs.LambdaSpecificationSpecs
{
    public class PriceSpec : LiteFx.Specification.LambdaSpecification<Product>
    {
        public override System.Linq.Expressions.Expression<Func<Product, bool>> Predicate
        {
            get { return p => p.Price > 0.49m; }
        }
    }
}
