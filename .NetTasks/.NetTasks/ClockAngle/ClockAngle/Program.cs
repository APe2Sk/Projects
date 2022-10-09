// See https://aka.ms/new-console-template for more information
Console.WriteLine("Application for determining the lesser angle between hour arrow and minutes arrow on the analoge clock.");

#region Input data

// HOUR input
Console.WriteLine("Please enter the hour (number between 1 and 12):");

var hour = Console.ReadLine();
bool hourNumber = int.TryParse(hour, out int parsedHour);

if(hourNumber == true && parsedHour >= 1 && parsedHour <= 12)
{
    Console.WriteLine($"You inputted {parsedHour}.");
}
else
{
    Console.WriteLine($"You must input number between 1 and 12. You inputted {parsedHour}");
    return;
}


// MINUTES input
Console.WriteLine("Please enter the minutes (number between 0 and 59):");

var minutes = Console.ReadLine();
bool minutesNumber = int.TryParse(minutes, out int parsedMinutes);

if (minutesNumber == true && parsedMinutes >= 0 && parsedMinutes <= 59)
{
    Console.WriteLine($"You inputted {parsedMinutes}.");
}
else
{
    Console.WriteLine($"You must input number between 1 and 12. You inputted {parsedMinutes}");
    return;
}

#endregion

double calculateLesserAngle(int hour, int minutes)
{
    //position of hour arrow
    var hourPositionWithoutMinutes = (360 / 12) * hour;
    var hourPositionWithMinutes = ((360 / 12) / 60.0) * minutes;
    var hourPosition = hourPositionWithoutMinutes + hourPositionWithMinutes;

    //position of minutes arrow
    var minutesPosition = (360 / 60) * minutes;

    //calculation the degree
    var angleDegrees = Math.Abs(hourPosition - minutesPosition);

    //determining the lesser degree
    if (angleDegrees > 180)
    {
        var result = 360 - angleDegrees;
        Console.WriteLine($"The lesser angle is {result} degrees.");
        return result;
    }
    if(angleDegrees == 180)
    {
        Console.WriteLine($"Both sides are equal, {angleDegrees} degrees.");
        return angleDegrees;
    }
    else
    {
        Console.WriteLine($"The lesser angle is {angleDegrees} degrees.");
        return angleDegrees;
    }
}

// Call of function for calculation the lesser degree (user input the hour and minutes)
calculateLesserAngle(parsedHour, parsedMinutes);