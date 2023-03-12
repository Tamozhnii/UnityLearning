int minutesPerHour = 60;
int receptionTimeInMinutes = 10;
int hospitalQueue = 14;

int waitingTime = hospitalQueue * receptionTimeInMinutes;
int hours = waitingTime / minutesPerHour;
int minutes = waitingTime % minutesPerHour;

Console.WriteLine($"Вы должны отстоять в очереди {hours} часа и {minutes} минут.");
