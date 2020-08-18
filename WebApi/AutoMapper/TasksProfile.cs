using AutoMapper;
using Domain.Commands;
using Domain.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.AutoMapper
{
    public class TasksProfile:Profile
    {
        public TasksProfile()
        {
            CreateMap<CreateMemberTaskCommand, Domain.DataModels.Task>();

        }
    }


    
}
