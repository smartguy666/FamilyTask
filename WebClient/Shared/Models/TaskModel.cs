using System;

public class TaskModel
{
    public Guid id {get; set;}
    public FamilyMember member { get; set; }
    public string text { get; set; }
    public bool isDone { get; set; }
}
