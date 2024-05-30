namespace TodoFramework.Domain.Aggregates;

public interface IRepository<TIdentity,TState> where TState: State<TIdentity> where TIdentity : Identity
{
    Task<TState?> FetchOrDefault(TIdentity identity);
    TState Initialize();
    Task Save(TState state);
}