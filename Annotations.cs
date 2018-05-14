namespace LibConsole
{
    using System;

    public abstract class NumberNameDescriptionAttribute : Attribute
    {
        public NumberNameDescriptionAttribute(string number,
                                              string name,
                                              string description)
        {
            this.Number = number;
            this.Name = name;
            this.Description = description;
        }

        public string Name { get; }
        public string Number { get; }
        public string Description { get; }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class ExerciseAttribute : NumberNameDescriptionAttribute
    {
        public ExerciseAttribute(string number, string name, string description = "")
            : base(number, name, description)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class TaskAttribute : NumberNameDescriptionAttribute
    {
        public TaskAttribute(string number, string name, string description = "")
            : base(number, name, description)
        {
        }
    }
}