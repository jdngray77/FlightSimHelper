namespace MSFSHelper.Core.Services;

public interface IAlertService
{
    Task<bool> ShowAlertAsync(string message, string title, string yesButtonText, string noButtonText);
    Task ShowAlertAsync(string message, string title, string ackButton);
}