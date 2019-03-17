using System;

namespace CommandPatternExample
{
    /// <summary>
    /// 
    /// Encapsulate a request as an object, thereby letting you 
    /// parameterize clients with different requests, queue or 
    /// log requests, and support undoable operations.
    /// 
    /// 
    /// Participants
    ///
    //The classes and objects participating in this pattern are:
    /// Command  (Command)
    //declares an interface for executing an operation
    //ConcreteCommand(CalculatorCommand)
    //defines a binding between a Receiver object and an action
    //implements Execute by invoking the corresponding operation(s) on Receiver
    //Client(CommandApp)
    //creates a ConcreteCommand object and sets its receiver
    //Invoker(User)
    //asks the command to carry out the request
    //Receiver(Calculator)
    //knows how to perform the operations associated with carrying out the request.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            Receiver receiver = new Receiver();
            Command command = new ConcreteCommand(receiver);
            Invoker invoker = new Invoker();

            invoker.SetCommand(command);
            invoker.ExecuteCommand();

            Console.ReadKey();
        }
    }

    abstract class Command
    {
        protected Receiver receiver;

        public Command(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public abstract void Execute();
    }

    class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver) :
            base(receiver)
        {
        }

        public override void Execute()
        {
            receiver.Action();
        }
    }

    class Receiver
    {
        public void Action()
        {
            Console.WriteLine("Called Receiver.Action()");
        }
    }

    class Invoker
    {
        private Command _command;

        public void SetCommand(Command command)
        {
            this._command = command;
        }

        public void ExecuteCommand()
        {
            _command.Execute();
        }
    }
}
