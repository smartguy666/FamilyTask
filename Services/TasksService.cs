using AutoMapper;
using Core.Abstractions.Repositories;
using Core.Abstractions.Services;
using Domain.Commands;
using Domain.DataModels;
using Domain.Queries;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TasksService : ITasksService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;
        public TasksService(IMapper mapper, ITaskRepository taskRepository,IMemberRepository memberRepository)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
            _memberRepository = memberRepository;
        }

        public async Task<CreateMemberTasksCommandResult> CreateMemberTaskCommandHandler(CreateMemberTaskCommand command)
        {
            var member_task = _mapper.Map<Domain.DataModels.Task>(command);
            var persistedMember = await _taskRepository.CreateRecordAsync(member_task);

            //var vm = _mapper.Map<MemberTasksVm>(persistedMember);

            MemberTasksVm vm = new MemberTasksVm();
            vm.AssignedToId = persistedMember.AssignedToId;
            vm.Subject = persistedMember.Subject;
            vm.Id = persistedMember.Id;
            vm.IsComplete = persistedMember.IsComplete;


            return new CreateMemberTasksCommandResult()
            {
                Payload = vm
            };
        }

        public async Task<GetAllMemberTasksQueryResult> GetAllMemberTasksQueryHandler()
        {
            

            var tasks = await _taskRepository.Reset().ToListAsync();
            List<MemberTasksVm> vdm = new List<MemberTasksVm>();
            if (tasks != null && tasks.Any()) 
            {
               
                foreach (var data in tasks) 
                {
                    MemberTasksVm res = new MemberTasksVm();
                    res.Id = data.Id;
                    res.AssignedToId = data.AssignedToId;
                    res.IsComplete = data.IsComplete;
                    res.Subject = data.Subject;                   
                    var members = await _memberRepository.Reset().ToListAsync();
                    var result = members.First(a => a.Id == res.AssignedToId);
                    MemberVm mem = new MemberVm();
                    mem.Avatar = result.Avatar;
                    mem.Email = result.Email;
                    mem.FirstName = result.FirstName;
                    mem.LastName = result.LastName;
                    mem.Roles = result.Roles;
                    res.Members = mem;
                    vdm.Add(res);
                }
            }
            IEnumerable<MemberTasksVm> vm = new List<MemberTasksVm>();
            vm = vdm;
            //vm = _mapper.Map<IEnumerable<MemberTasksVm>>(tasks);

            return new GetAllMemberTasksQueryResult()
            {
                Payload = vm
            };
        }



        public async Task<GetDeleteMemberQueryResults> DeleteTaskQueryHandler(Guid ID)
        {


           
            var result = await _taskRepository.DeleteRecordAsync(ID);
            //return false;



            return new GetDeleteMemberQueryResults()
            {
                Result = result > 0 ? true : false
            };
        }
    }

}