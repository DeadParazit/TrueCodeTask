﻿namespace TrueCodeUlanYeskendirovTask.Core.Models;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<ToDoItem> ToDoItems { get; set; }
}