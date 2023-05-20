using System;
using System.Collections.Generic;

// Receiver (Отримувач) - Клас, який виконує дії, пов'язані з обробкою даних
class DataProcessor
{
    private List<string> data = new List<string>();

    public void SaveData(string item)
    {
        data.Add(item);
        Console.WriteLine($"Data '{item}' saved.");
    }

    public void UpdateData(int index, string newItem)
    {
        if (index >= 0 && index < data.Count)
        {
            string oldItem = data[index];
            data[index] = newItem;
            Console.WriteLine($"Data at index {index} updated to '{newItem}'.");
        }
        else
        {
            Console.WriteLine($"Invalid index: {index}");
        }
    }

    public void DeleteData(int index)
    {
        if (index >= 0 && index < data.Count)
        {
            string item = data[index];
            data.RemoveAt(index);
            Console.WriteLine($"Data at index {index} deleted.");
        }
        else
        {
            Console.WriteLine($"Invalid index: {index}");
        }
    }

    public void DisplayData()
    {
        Console.WriteLine("Data:");
        foreach (string item in data)
        {
            Console.WriteLine(item);
        }
    }
}

// Command (Команда) - Базовий клас для команд
interface ICommand
{
    void Execute();
    void Undo();
}

// Concrete Command (Конкретна команда) - Команда для збереження даних
class SaveCommand : ICommand
{
    private DataProcessor receiver;
    private string item;

    public SaveCommand(DataProcessor receiver, string item)
    {
        this.receiver = receiver;
        this.item = item;
    }

    public void Execute()
    {
        receiver.SaveData(item);
    }

    public void Undo()
    {
        // Немає необхідності в реалізації Undo для цієї команди
        Console.WriteLine("Undo SaveCommand is not supported.");
    }
}

// Concrete Command (Конкретна команда) - Команда для оновлення даних
class UpdateCommand : ICommand
{
    private DataProcessor receiver;
    private int index;
    private string newItem;
    private string oldItem;

    public UpdateCommand(DataProcessor receiver, int index, string newItem)
    {
        this.receiver = receiver;
        this.index = index;
        this.newItem = newItem;
    }

    public void Execute()
    {
        //oldItem = receiver[index]; // Зберегти старе значення для Undo
        receiver.UpdateData(index, newItem);
    }

    public void Undo()
    {
        receiver.UpdateData(index, oldItem); // Відновити старе значення
    }
}

// Concrete Command (Конкретна команда) - Команда для видалення даних
class DeleteCommand : ICommand
{
    private DataProcessor receiver;
    private int index;
    private string deletedItem;

    public DeleteCommand(DataProcessor receiver, int index)
    {
        this.receiver = receiver;
        this.index = index;
    }

    public void Execute()
    {
        //deletedItem = receiver.GetItemAt(index); // Зберегти видалене значення для Undo
        receiver.DeleteData(index);
    }

    public void Undo()
    {
        receiver.SaveData(deletedItem); // Відновити видалене значення
    }
}

// Invoker (Ініціатор) - Клас, який ініціює виконання команд
class CommandInvoker
{
    private Stack<ICommand> history = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        history.Push(command); // Додати команду до історії
    }

    public void UndoLastCommand()
    {
        if (history.Count > 0)
        {
            ICommand command = history.Pop();
            command.Undo();
        }
        else
        {
            Console.WriteLine("No commands to undo.");
        }
    }
}

