namespace ProjectFolder.Models;

public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}

public class DataSharing
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Message { get; set; }
    public bool IsChecked { get; set; } = false;
}