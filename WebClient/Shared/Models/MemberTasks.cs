using System;

    public class MemberTasks
    {
        public Guid Id { get; set; }

        public string Subject { get; set; }
        public bool IsComplete { get; set; }
        public Guid AssignedToId { get; set; }

        public FamilyMember Members { get; set; }
}

public class DeleteMember
{
    public bool Result { get; set; }
}
