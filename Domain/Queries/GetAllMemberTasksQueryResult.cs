using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Queries
{
    public class GetAllMemberTasksQueryResult
    {
        public IEnumerable<MemberTasksVm> Payload { get; set; }
    }
}
