using JobFinder.Entities.DTOs.CompanyDTOs;
using JobFinder.Entities.DTOs.JobDTOs;
using JobFinder.Entities.DTOs.JobSeekerDTOs;
using JobFinder.Entities.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Entities
{
    public static class MapsterConfiguration
    {
        public static void ConfigureMapster()
        {
            TypeAdapterConfig<Job, JobDto>.NewConfig();
            TypeAdapterConfig<Company, CompanyDto>.NewConfig();
            TypeAdapterConfig<Company, CompanyDto>.NewConfig();
            TypeAdapterConfig<JobSeeker, JobSeekerDto>.NewConfig();
            TypeAdapterConfig<JobSeeker, JobSeekerDto>.NewConfig();
        }
    }
}
