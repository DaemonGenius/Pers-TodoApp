using Moq;
using TaskService.Domain;
using TaskService.Domain.Events;
using TaskStatus = TaskService.Domain.TaskStatus;

namespace TaskServiceTests.Unit;

public class TaskServiceTests
{
    private Mock<ITaskRepository> _mockRepository;
    private TaskService.Application.TaskService _taskService;

    [SetUp]
    public void Setup()
    {
        _mockRepository = new Mock<ITaskRepository>();
        _taskService = new TaskService.Application.TaskService(_mockRepository.Object);
    }

    [Test]
    public async Task CreateTask_Should_CreateTask_Successfully()
    {
        // Arrange
        var title = "Test Task";
        var description = "Task Description";
        var dueDate = DateTimeOffset.UtcNow.AddDays(1);
        var priority = 1;

        var taskIdentity = new TaskIdentity(Guid.NewGuid());
        var taskState = new TaskState(taskIdentity);

        _mockRepository
            .Setup(repo => repo.Initialize())
            .Returns(taskState);

        _mockRepository
            .Setup(repo => repo.Save(It.IsAny<TaskState>()))
            .Returns(Task.CompletedTask);

        try
        {
            // Act
            var result = await _taskService.CreateTask(title, description, dueDate, priority);

            // Assert
            _mockRepository.Verify(repo => repo.Save(It.Is<TaskState>(state =>
                state.Title == title &&
                state.Description == description &&
                state.DueDate == dueDate &&
                state.Priority == priority &&
                state.Status == TaskStatus.Active)), Times.Once);

            Assert.NotNull(result);
            Assert.That(result, Is.EqualTo(taskIdentity));
        }
        catch (Exception ex)
        {
            // Log error details
            Assert.Fail($"Exception thrown during test execution: {ex.Message}");
        }
    }

    [Test]
    public async Task UpdateTask_Should_UpdateTaskInformation_Successfully()
    {
        // Arrange
        var identity = new TaskIdentity(Guid.NewGuid());
        var title = "Updated Task";
        var description = "Updated Description";
        var dueDate = DateTimeOffset.UtcNow.AddDays(2);
        var priority = 2;

        var taskState = new TaskState(identity);
        taskState.When(new TaskCreated
        {
            Title = "Original Task",
            Description = "Original Description",
            DueDate = DateTimeOffset.UtcNow.AddDays(1),
            Priority = 1
        });

        _mockRepository
            .Setup(repo => repo.FetchOrDefault(identity))
            .ReturnsAsync(taskState);

        _mockRepository
            .Setup(repo => repo.Save(It.IsAny<TaskState>()))
            .Returns(Task.CompletedTask);

        // Act
        await _taskService.UpdateTask(identity, title, description, dueDate, priority);

        // Assert
        _mockRepository.Verify(repo => repo.Save(It.Is<TaskState>(state =>
            state.Title == title &&
            state.Description == description &&
            state.DueDate == dueDate &&
            state.Priority == priority &&
            state.Status == TaskStatus.Active)), Times.Once);
    }

    [Test]
    public async Task RemoveTask_Should_MarkTaskAsRemoved_Successfully()
    {
        // Arrange
        var identity = new TaskIdentity(Guid.NewGuid());

        var taskState = new TaskState(identity);
        taskState.When(new TaskCreated
        {
            Title = "Task to be Removed",
            Description = "Description",
            DueDate = DateTimeOffset.UtcNow.AddDays(1),
            Priority = 1
        });

        _mockRepository
            .Setup(repo => repo.FetchOrDefault(identity))
            .ReturnsAsync(taskState);

        _mockRepository
            .Setup(repo => repo.Save(It.IsAny<TaskState>()))
            .Returns(Task.CompletedTask);

        // Act
        await _taskService.RemoveTask(identity);

        // Assert
        _mockRepository.Verify(repo => repo.Save(It.Is<TaskState>(state =>
            state.Status == TaskStatus.Expunged)), Times.Once);
    }
}