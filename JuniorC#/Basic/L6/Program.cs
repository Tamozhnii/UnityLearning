int minutesPerHour = 60;
int receptionTimeInMinutes = 10;
int hospitalQueue = 14;

int waitingTime = hospitalQueue * receptionTimeInMinutes;
int waitingHours = waitingTime / minutesPerHour;
int waitingMinutes = waitingTime % minutesPerHour;

Console.WriteLine($"Вы должны отстоять в очереди {waitingHours} часа и {waitingMinutes} минут.");
