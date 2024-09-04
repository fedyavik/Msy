namespace MSY.Database.Models;

/// <summary>
/// Данные от прибора
/// </summary>
public class ModuleData
{
    /// <summary>
    /// Номер записи
    /// </summary>
    public long Id { get; set; }
    /// <summary>
    /// Номер объекта
    /// </summary>
    public long ObjectId { get; set; }
    /// <summary>
    /// Имя объекта
    /// </summary>
    public string ObjectName { get; set; }
    /// <summary>
    /// Когда были получены данные от прибора
    /// </summary>
    public DateTime CreatedAt { get; set; }
    /// <summary>
    /// Данные от прибора
    /// </summary>
    public string Payload { get; set; }
}