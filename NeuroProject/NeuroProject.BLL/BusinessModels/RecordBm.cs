using NeuroProject.BLL.Enums;

namespace NeuroProject.BLL.BusinessModels;

public class RecordBm
{
    public Guid Id { get; set; }

    public RecordCategories Category { get; set; }
}