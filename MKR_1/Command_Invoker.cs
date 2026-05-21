using System.Collections.Generic;

namespace StructuralPatternsLab
{
    public class Command_Invoker
    {
        private Stack<Command_ICommand> _history = new Stack<Command_ICommand>();

        public void ExecuteCommand(Command_ICommand command)
        {
            command.Execute();
            _history.Push(command);
        }

        public void Undo()
        {
            if (_history.Count > 0)
            {
                var command = _history.Pop();
                command.Undo();
            }
        }
    }
}
