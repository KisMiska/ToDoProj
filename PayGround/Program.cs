using ToDo.Core.Models;

ToDoItem item = new ToDoItem()
{
    id = Guid.NewGuid(),
    title = "Title",
    description = "dsfasfbsadcfgsadgshfgjhdhkfdkashj gusdhguhs ",
    created = DateTime.Now,
    importance = ToDo.Core.Models.Enums.Importance.Iportant
};

