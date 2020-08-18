using Core.Abstractions.Repositories;
using Domain.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class TasksRepository : BaseRepository<Guid, Domain.DataModels.Task, TasksRepository>, ITaskRepository
    {
        public TasksRepository(FamilyTaskContext context) : base(context)
        { }
       

        ITaskRepository IBaseRepository<Guid, Domain.DataModels.Task, ITaskRepository>.NoTrack()
        {
            return base.NoTrack();
        }

      

        ITaskRepository IBaseRepository<Guid, Domain.DataModels.Task, ITaskRepository>.Reset()
        {
            return base.Reset();
        }
    }



   
}
