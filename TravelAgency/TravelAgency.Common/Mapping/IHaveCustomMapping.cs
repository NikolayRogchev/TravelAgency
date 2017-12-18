using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.Common.Mapping
{
    public interface IHaveCustomMapping
    {
        void ConfigureMapping(Profile profile);
    }
}
