using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection.Metadata;
using System.Text;
using System.Windows.Input;

public class MainViewModel : INotifyPropertyChanged
{
    private string _taskTitle;
    public string TaskTitle
    {
        get => _taskTitle;
        set
        {
            if (_taskTitle != value)
            {
                _taskTitle = value;
                OnPropertyChanged(nameof(TaskTitle));
            }
        }
    }

    public ObservableCollection<TaskModel> Tasks { get; set; }

    public ICommand AddTaskCommand { get; set; }
    public ICommand DeleteTaskCommand { get; set; }

    private readonly TaskService _taskService;

    public MainViewModel()
    {
        _taskService = new TaskService();

        Tasks = new ObservableCollection<TaskModel>(_taskService.GetAll());

        AddTaskCommand = new RelayCommand(_ => AddTask());
        DeleteTaskCommand = new RelayCommand(DeleteTask);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    private void AddTask()
    {
        if (!string.IsNullOrWhiteSpace(TaskTitle))
        {
            var task = new TaskModel { Title = TaskTitle, Description = "", DueDate = DateTime.Now.AddDays(1), IsCompleted = false };

            _taskService.Add(task);
            Tasks.Add(task);

            TaskTitle = ""; // reset champ
            OnPropertyChanged(nameof(TaskTitle));
        }
    }

    private void DeleteTask(object parameter)
    {
        if (parameter is TaskModel task)
        {
            _taskService.Delete(task);
            Tasks.Remove(task);
        }
    }
}
