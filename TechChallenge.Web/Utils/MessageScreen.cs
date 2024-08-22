using Microsoft.AspNetCore.Components;
using Radzen;

namespace TechChallenge.Web.Utils;
public static class MessageScreen
{
    public static void ShowMessage(NotificationService notificationService, string title, string subTitle, NotificationSeverity severity, double duration = 5000, int maxNotifications = 3)
    {
        if (duration < 2000)
        {
            duration = 2000;
        }

        var message = new NotificationMessage();
        message.Duration = duration;
        
        message.Style = "animation-name: animate-notification-in; " +
                        "animation-direction: normal; " +
                        $"animation-duration: {duration}ms; " +
                        "animation-fill-mode: both; " +
                        "animation-timing-function: ease-out; " +
                        "width: 400px;";
        message.Summary = title;
        message.Detail = subTitle;
        message.Severity = severity;

        if (notificationService.Messages.Count < maxNotifications)
        {
            notificationService.Notify(message);
        }
    }
    public static void ShowTooltip(TooltipService tooltipService, string text, ElementReference elementReference, TooltipOptions options = null) 
    {
        tooltipService.Open(elementReference, text, options);
    }
}